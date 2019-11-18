# Mongodb-Cluster-Test

Name : Deddy Aditya P.
NRP : 05111640000069

## About MongoDB cluster

Implementation is done using vagrant-virtualbox. There are 2 config servers, 3 shard servers and 1 query router. Here is the IP configuration:

```
192.168.16.69 mongo-query-router
192.168.16.70 mongo-config-1
192.168.16.71 mongo-config-2
192.168.16.72 mongo-shard-1
192.168.16.73 mongo-shard-2
192.168.16.74 mongo-shard-3
```

All VMs are running Ubuntu 18.04, MongoDB 4.2 with 512MB of RAM

## About Dataset

Currently I'm using [Animal Services Intake Data](https://data.lacity.org/api/views/8cmr-fbcu/rows.csv?accessType=DOWNLOAD) dataset in CSV form that contains 187,593 rows and 9 columns. I modified the header row to lower snake case for convenience purpose before importing.

## About CRUD Implementation

The simple CRUD application itself is written using ASP.NET Core MVC framework in C# language in form of Web API. There are 3 queries that using "aggregation" operation, but all of them are just "count" because it's the only aggregation operation that can be used on the dataset.