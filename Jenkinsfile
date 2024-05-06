pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/nandinimoonka/wpfapp.git'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build MaterialDesignToolkit.Full.sln'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true'
            }
        }

        stage('Archive') {
            steps {
                archiveArtifacts artifacts: '**/bin/Release/**'
            }
        }
    }
}
