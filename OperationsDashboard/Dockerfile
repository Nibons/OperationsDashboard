FROM windowsservercore as getnodejs

ENV NPM_CONFIG_LOGLEVEL info
ENV NODE_VERSION 4.4.5

#build the Node.JS executable
RUN powershell -Command \
    invoke-webrequest -Uri https://nodejs.org/dist/v%NODE_VERSION%/node-v%NODE_VERSION%-x64.msi -OutFile node.msi -UseBasicParsing ; \    
    Start-Process -FilePath msiexec -ArgumentList /q, /i, node.msi -Wait ; \
    Remove-Item -Path node.msi

FROM microsoft/aspnetcore:1.1
COPY --from=getnodejs nodejs /windows/system32
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "OperationsDashboard.dll"]