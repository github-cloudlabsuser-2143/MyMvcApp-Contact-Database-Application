# File: MyMvcApp-ARM-Template/scripts/deploy.ps1

# This script automates the deployment of the ARM template to Azure.

# Define variables
$resourceGroupName = "<your-resource-group-name>"
$templateFile = "../templates/azuredeploy.json"
$parameterFile = "../templates/azuredeploy.parameters.json"
$location = "<your-location>"

# Login to Azure
az login

# Create resource group if it doesn't exist
az group create --name $resourceGroupName --location $location

# Deploy the ARM template
az deployment group create --resource-group $resourceGroupName --template-file $templateFile --parameters @$parameterFile

# Output deployment status
Write-Host "Deployment completed."