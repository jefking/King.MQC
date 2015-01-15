Model Queue Controller
========

## ALPHA - PRE-RELEASE

### Current
- Routing setup (Controller Classes)
- Call methods via routing

### Notes
web api everything
you dont wire anything up
queues could go in place of each layer, if needed

web call -> web api -> dal -> storage
web call -> web api -> queue -> dal (web api) -> queue -> storage

each place failure is handled, and retry is handled

model based throughout system.
each unit is scalable.

multiple language support; route between languages

1 mockable class: Get/Put, url + data
makes testing really nice, as you dont have to worry about mocking and dependancies as much.

High entropy, many smaller parts

### TODO
Controllers
- Stateful? Should be able to load just one and keep using it? Cache
- Retry for queue/dequeue etc

Calling
- Thread models, single threaded, eventing, etc.
- Failures
- App domains

Queue Types
- Direct, no-queue
- Local, in memory queue
- Azure Storage
- Service Bus
- etc.