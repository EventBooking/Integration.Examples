# Integrating with VenueOps via the Open API

# The `OpenApiBasicExample` app

The `OpenApiBasicExample` shows how to authenticate with the Open API and to make a call. Before using it, you will need to get a `ClientId` and `ClientSecret` from the EventBooking staff and place them in the appropriate location in `Program.cs`.

See the [Open API documentation](http://help-api.indv-venueops.com/) for all the services that it provides.

# Integrating with VenueOps via SQS

This code example in this repository shows how to send and retrieve messages from an AWS SQS queue. This is one of several ways that EventBooking provides "push" notifications from VenueOps for integration purposes.

## Why SQS?

The first advantage is that both systems rely on a third service and need to have very little knowledge of each other. This third service is simple, well-understood, and reliable.

The second advantage is that a queue can buffer messages between systems so that downtime of one does not affect the other. Messages simple stack up in the queue until the receiving system is operational.

The third advantage is that unexpected traffic will not cause unnecessary load on a system. If one system is limited in the speed with thich it can process messages, again, the messages will simply stack up until they are processed.

## Using AWS

* [Getting started with AWS](https://aws.amazon.com/getting-started/).

## The `SqsExample` app

You will need to add your own settings in the `Program.cs` file. If you're not sure what to put in `Region`, check the `QueueUrl`. As of this writing, the valid choices for `Region` are:

| Code| Name |
| --- | --- |
| us-east-1 | US East (N. Virginia)
| us-west-2 | US West (Oregon)
| us-west-1 | US West (N. California)
| eu-west-1 | EU (Ireland)
| eu-central-1 | EU (Frankfurt)
| ap-southeast-1 | Asia Pacific (Singapore)
| ap-northeast-1 | Asia Pacific (Tokyo)
| ap-southeast-2 | Asia Pacific (Sydney)
| ap-northeast-2 | Asia Pacific (Seoul)
| ap-south-1 | Asia Pacific (Mumbai)
| sa-east-1 | South America (São Paulo)

Once you have set up the sample app, you should be able to use it to send and receive messages from a queue.
