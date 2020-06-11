node {

  stage('Checkout') {
    git url:'https://github.com/dguia18/AplicacionDulcesYMas.git',branch: 'master'
  }
  //SignusFinanciero.sln
  stage ('Restore Nuget') {
    bat "dotnet restore AplicacionDulcesYMas.sln"
  }
  
  stage('Clean') {
    bat 'dotnet clean AplicacionDulcesYMas.sln'
  }
  
  stage('Build') {
    bat 'dotnet build AplicacionDulcesYMas.sln --configuration Release'
  }

  stage ('Test') {
    bat "dotnet test CompositeDulcesTest/DomainTest.csproj --logger trx;LogFileName=unit_tests.trx"
    mstest testResultsFile:"**/*.trx", keepLongStdio: true
  }
    

  stage('Publish') {
    bat 'dotnet publish WebApiAngular/WebApiAngular.csproj -c Release -o C:/DeployDulcesYmas'
  } 
  
}