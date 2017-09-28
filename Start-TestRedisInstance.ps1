#this starts a new redis instance, which we can use to test.
begin{
	$redisInstance = docker ps -aq --filter name=redis
	if($redisInstance){
		docker rm -f $redisInstance
	}
}
Process{
	#start the instance
	docker run -d --name redis --hostname redis -p 6379:6379 redis:nanoserver 


	#retrieve data from the instance
	$redis_inspection = docker inspect redis | ConvertFrom-Json
	$list_network = $redis_inspection.NetworkSettings.Networks
	[string[]]$network_Names = $list_network | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty name
	foreach($netName in $network_Names){
		$ipAddress = $list_network.$netName | Select-Object -ExpandProperty IPAddress
		Write-Output "IP: $ipAddress"
	}

	#begin monitoring the instance, outputing to STDOUT
	docker exec redis redis-cli monitor
}
End{
	#stop+remove the instance
	docker rm -f redis
}