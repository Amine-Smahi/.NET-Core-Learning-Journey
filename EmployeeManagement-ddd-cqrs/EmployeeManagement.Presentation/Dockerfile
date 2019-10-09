FROM microsoft/dotnet:3.0-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:3.0-sdk AS build
WORKDIR /src
COPY ["EmployeeManagement.Presentation/EmployeeManagement.Presentation.csproj", "Equinox.UI.Web/"]
RUN dotnet restore "EmployeeManagement.Presentation/EmployeeManagement.Presentation.csproj"
COPY . .
WORKDIR "/src/EmployeeManagement.Presentation"
RUN dotnet build "EmployeeManagement.Presentation.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EmployeeManagement.Presentation.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeManagement.Presentation.dll"]