ALPHA
========

+ Routing setup (Controller Classes)
+ Call methods via routing
+ NuGet: Install-Package King.MQC
+ 100% test coverage

## Notes

### Goals
From: web call -> web api -> dal -> storage

To: web call -> web api -> queue -> dal -> queue -> storage

### Benefits
+ High entropy, many smaller parts
+ multiple language support; route between languages
+ Models
 + Code MVC style
 + Model based throughout system, not just first layer
+ Scalability
 + queues could go in place of each layer
 + each controller method becomes scalable
 + each place failure is handled, and retry is handled
+ Testing
 + 1 mockable class: Get/Put, url + data
 + makes testing really nice, as you dont have to worry about mocking and dependancies as much
 + you don't inject classes that are dependancies

### TODO/Ideas
Controllers
+ Stateful? Should be able to load just one and keep using it? Cache
+ Retry for queue/dequeue etc

Calling
+ Thread models, single threaded, eventing, etc.
+ Failures
+ App domains

Queue Types
+ Direct Route, no-queue (done)
+ Local Queue, in memory queue (in progress)
+ Azure Storage (future)
+ Service Bus (future)