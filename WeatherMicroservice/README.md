# Description
Build and deploy an ASP.NET Core microservice in a Docker container

## Goal
* How to create a development Docker environment.
* How to build a Docker image based on an existing image.
* How to deploy your service into a Docker container.

## Test the application
You build the image using the docker build command. Run the following command from the directory containing your code.

     docker build -t weather-microservice .

Run the following command to start the container and launch your service:

     docker run -d -p 80:80 --name hello-docker weather-microservice
    
You can test your service by opening a browser and navigating to localhost, and specifying a latitude and longitude:

    http://localhost/?lat=35.5&long=40.75

The response will be a json that contains

![image](https://user-images.githubusercontent.com/24621701/44582078-32908600-a798-11e8-9ea8-143705d3b9f8.png)


