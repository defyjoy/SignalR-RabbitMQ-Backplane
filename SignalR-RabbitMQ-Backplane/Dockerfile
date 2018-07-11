FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "kubeaspnetapp.dll"]


###############################################################################################


# Build it 
# docker build -t dotnetapp-prod  .

# Run it
# docker run -d -p 5050:5050 dotnetapp-prod

# Browse it 
# http://192.168.99.100:5050/hello/index


# To run it on KUBERNETES 
# minikube start
# minikube docker-env

# kubectl run 
# kubectl run connectcd --image=kepung/dotnetapp-prod --port=5050 
# Exposing kubernetes service 
# kubectl expose deployment/connectcd  --type="NodePort" --port=5050 --name=connectcd-http

# Get the minikube / kubernete ip and paste in your exposed IP 
# Look under Addresses:
#  InternalIP:  192.168.99.100
#  Hostname:    minikube

# kubectl describe node 

# kubectl get service/connectcd-http
# Get the port which looks something like this :- 
#NAME             TYPE       CLUSTER-IP      EXTERNAL-IP   PORT(S)          AGE
#connectcd-http   NodePort   10.103.83.222   <none>        5050:32206/TCP   8m

# Other useful command 
# kubectl delete pods --all 


#Debugging and troubleshooting 
#kubectl get po then, 
#docker run -it dotnetapp-prod bash

#Kubernetes debugging 
#kubectl exec -it connectcd-545c87f8d8-k8hgz /bin/bash

#FROM microsoft/dotnet:2.1-sdk AS build-env
#WORKDIR /app
#EXPOSE 80
#
## copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
#
### copy everything else and build
##COPY . ./
##RUN dotnet publish -c Release -r linux-x64 -o out
##
### build runtime image
##FROM microsoft/dotnet:2.0-runtime 
##WORKDIR /app
##COPY --from=publish /app .
#
#FROM build AS publish
#RUN dotnet publish SignalRRAbbitMQBackplane.csproj -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app . 
#
#ENTRYPOINT ["dotnet", "SignalRRAbbitMQBackplane.dll"]