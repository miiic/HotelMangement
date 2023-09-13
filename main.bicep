@description('Web app name.')
@minLength(2)
param webAppName string = 'api-hotel-management-${uniqueString(resourceGroup().id)}'

@description('Location for all resources.')
param location string = resourceGroup().location

param sku string = 'F1' //Free tier

var appServicePlanName = 'AppServicePlan-${webAppName}'

resource asp 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: sku
  }
}

resource webApp 'Microsoft.Web/sites@2022-03-01' = {
  name: webAppName
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    siteConfig: {
      minTlsVersion: '1.2'
      scmMinTlsVersion: '1.2'
      ftpsState: 'FtpsOnly'
    }
    serverFarmId: asp.id
    httpsOnly: true
  }
}

var vaultName = 'kv-hotel-management'
var keyNames = ['sqlPassword']
module vaultModule 'vault.bicep' = {
    name: 'keyVault'
    params: {
        location: location
        name: vaultName
        keyNames: keyNames
    }
}

resource kv 'Microsoft.KeyVault/vaults@2022-07-01' existing = {
  name: vaultName
}

param sqlServerName string = 'api-hotel-management'
param sqlAdminLogin string = 'UserHotelManagementAdmin'
module sql './sql.bicep' = {
  name: 'deploySQL'
  params: {
    sqlServerName: sqlServerName
    adminLogin: sqlAdminLogin
    adminPassword: kv.getSecret('sqlPassword')
  }
}

