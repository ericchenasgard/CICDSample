pipeline {
  agent any
  stages {
    stage('Build Image') {
      steps {
        powershell 'docker build -t cicdsample .'
      }
    }

    stage('Stop') {
      steps {
        powershell 'docker stop net_core_common '
      }
    }

    stage('Run') {
      steps {
        powershell 'docker run -dt --rm -p 8888:80 --name net_core_common net_core_common '
      }
    }

  }
}