pipeline {
    agent any
    environment {
        registryUrl = 'https://index.docker.io/v1'
    }
    options {
      skipDefaultCheckout()
      timestamps()
      disableConcurrentBuilds()
   }
   parameters {
       string(name: 'ApplicationName', defaultValue: '', description:'Application Name')
       string(name: 'ImageName', defaultValue: '', description:'Image Name')
       string(name: 'ImageTag', defaultValue: '', description:'Image tag')
   }
   stages {
       stage('Clean Work Space') {
            steps {
                cleanWs()
            }
        }
        stage('Pull Image') {
            steps {
                script {
                    artifacts = "${params.ImageName}:${params.ImageTag}"
                    docker.image(artifacts).pull()
                }
            }
            
        }
        
        stage('Deploy Image') {
            steps {
                script {
                    withCredentials([azureServicePrincipal('az-demo-sp')]) {
                    bat "az --version"
                    bat "az login --service-principal -u $AZURE_CLIENT_ID -p $AZURE_CLIENT_SECRET -t $AZURE_TENANT_ID"
                    bat "az account set -s $AZURE_SUBSCRIPTION_ID"
                    bat "az webapp config container set --name ${params.ApplicationName} --resource-group RG-Demo-ACI --docker-custom-image-name ${artifacts} --docker-registry-server-url ${registryUrl}"
                    bat "az logout"
                }
                }
            }
            
        }
        stage('Post Actions') {
            steps {
                script {
                    echo "Pipeline Finished"
                }
            }
        }
   }
}