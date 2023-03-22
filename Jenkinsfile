pipeline {
  agent any
  stages {
    stage('Build Image') {
      steps {
        powershell 'docker build -t cicdsample .'
      }
    }

  }
}