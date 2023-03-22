pipeline {
  agent any
  stages {
    stage('Build Image') {
      steps {
        pwsh 'docker build -t cicdsample .'
      }
    }

  }
}