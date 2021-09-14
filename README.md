## Run
afer executing `docker-compose -f docker-compose.yml up` then 
you can navigate to  `http://localhost:3000` for UI project 

## Grpc
for grpc checking, you can use below command. 
`grpcui -plaintext localhost:5000`
we can add grpc reflectin too.

## Rest
the end points are :
 http://localhost:5001/api/Analytics/StartCalculation
 http://0.0.0.0:5001/api/Analytics/GetStatus/{id}


