ALPHA
========

+ NuGet: Install-Package King.MQC
+ 100% test coverage

## Notes

### Goals
From: http -> web api -> dal -> storage

To: http -> web api -> queue -> dal -> queue -> storage

### Benefits
+ Scalability
 + queues could go in place of each layer
 + each controller method becomes scalable
 + each place failure is handled, and retry is handled

### Ideas
Controllers
+ Retry for queue/dequeue etc

Calling
+ Thread models, single threaded, eventing, etc.
+ Failures
+ App domains

Queue Types
+ Local Queue, in memory queue (in progress)
+ Azure Storage (future)
+ Service Bus (future)