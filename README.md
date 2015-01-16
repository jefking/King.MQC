ALPHA - PRE-RELEASE
========

## Current
- Routing setup (Controller Classes)
- Call methods via routing
- NuGet: Install-Package King.MQC
- 100% test coverage

## Notes

### Goal
web call -> web api -> dal -> storage
web call -> web api -> queue -> dal (web api) -> queue -> storage

### Benefits
- High entropy, many smaller parts
- model based throughout system
- each controller is a unit of scale
- web api style
- 1 mockable class: Get/Put, url + data
- makes testing really nice, as you dont have to worry about mocking and dependancies as much
- you don't inject classes that are dependancies
- queues could go in place of each layer
- each place failure is handled, and retry is handled

### Future
- multiple language support; route between languages

### TODO/Ideas
Controllers
- Stateful? Should be able to load just one and keep using it? Cache
- Retry for queue/dequeue etc

Calling
- Thread models, single threaded, eventing, etc.
- Failures
- App domains

Queue Types
- Direct Route, no-queue (done)
- Local Queue, in memory queue (in progress)
- Azure Storage (future)
- Service Bus (future)