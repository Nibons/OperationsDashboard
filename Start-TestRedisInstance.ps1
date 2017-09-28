#this starts a new redis instance, which we can use to test.
docker run -d --name redis -p 6379:6379 redis:nanoserver 
$redis_inspection = docker inspect redis | ConvertFrom-Json
$list_network = $redis_inspection.NetworkSettings.Networks
[string[]]$network_Names = $list_network | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty name
foreach($netName in $network_Names){
	$ipAddress = $list_network.$netName | Select-Object -ExpandProperty IPAddress
	Write-Output "IP: $ipAddress"
}
docker exec redis redis-cli monitor