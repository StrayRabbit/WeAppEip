FROM microsoft/dotnet:2.2-sdk AS build

COPY . /eip

WORKDIR /eip

EXPOSE 80

CMD ["dotnet","WeAppEip.Web.dll", "--server.urls", "http://*:80"]