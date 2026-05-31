Image and build Creation:
docker build -t smartkart-identity:v1 .

Run container:
docker run -d -p 5001:8080 --name identity-api smartkart-identity:v1

Check runing container:
docker ps

Stop container:
docker stop identity-api