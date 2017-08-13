## Prerequisites:
## - Python 3.5.2:  https://www.python.org/downloads/release/python-352/
## - Azure CLI 2.0: https://docs.microsoft.com/en-us/cli/azure/install-azure-cli
##

$ResourceGroup="Case-MjrCenter"
az login -u msdn@euri.com -p <password>
az group deployment create --resource-group $ResourceGroup --template-uri https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/docker-simple-on-ubuntu/azuredeploy.json --parameters '@createParams.json'
az vm show --resource-group $ResourceGroup --name myDockerVM --query [provisioningState] --output tsv
az vm show -g $ResourceGroup -n myDockerVM -d --query [fqdns] -o tsv
