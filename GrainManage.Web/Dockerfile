FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app
 
EXPOSE 8080/tcp
ENV ASPNETCORE_URLS http://*:8080

ENTRYPOINT ["dotnet", "GrainManage.Web.dll"]
