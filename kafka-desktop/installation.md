

## Step 1: 
Download Binaries from https://kafka.apache.org/downloads 

## Step 2: 
extract the file **kafka_2.13-3.4.1.tgz** into C://kafka

## Step 3: 
Copy the path of the Kafka folder. Now go to config inside kafka folder and open zookeeper.properties file. Copy the path against the field dataDir and add /zookeeper-data to the path.

## Step 4:
Now in the same folder config open server.properties and scroll down to log.dirs and paste the path. To the path add /kafka-logs

## Step 5:
This completes the configuration of zookeeper and kafka server. Now open command prompt and change the directory to the kafka folder. First start zookeeper using the command given below:

```bash
.\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties
```
## Step 6:
Now open another command prompt and change the directory to the kafka folder. Run kafka server using the command:
```bash
.\bin\windows\kafka-server-start.bat .\config\server.properties
```


https://www.geeksforgeeks.org/how-to-install-and-run-apache-kafka-on-windows/