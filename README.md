Pusher-Universal
==========

A Pusher client for Universal Windows Apps.  Forked from digitalcreations/Pusher.NET


Install
-------

Using Nuget:
```
PM> Install-Package pusher-unversal
```

How to use
----------

```csharp
var pusher = new Pusher(new WebsocketConnectionFactory(), appKey);
await pusher.ConnectAsync();

var fooChannel = await pusher.SubscribeToChannelAsync("foo");

fooChannel.EventEmitted += (sender, evt) => 
	{
		Debug.WriteLine(evt.Data);
	};
```


HTTPS
-----

Use the options object to enable HTTPS:

```csharp
var pusher = new Pusher(new WebsocketConnectionFactory(), appKey, new Options
	{
		Scheme = WebServiceScheme.Secure
	});
```

Authenticators
--------------

If you want to use private or presence channels, you will have to implement a simple authenticator. How you do this is dependent on your existing infrastructure. You provide the authenticator through the Pusher options object:

```csharp
var pusher = new Pusher(new WebsocketConnectionFactory(), appKey, new Options
	{
		Authenticator = new MyAuthenticator(whatever, parameters, youNeed)
	});
```

Event contracts
---------------

By default events that are raised contain a string Data field which is straight-up JSON code returned from the server. If you want statically typed access to this object, you will have to provide an event contract.

An event contract is most easily created by registering with Pusher:

```csharp
[DataContract]
class SomeDataStructure
{
	[DataMember(Name = "id")]
	public int Id { get; set; }
}

pusher.AddContract(EventContract.Create<SomeDataStructure>("event name"));
```

Now, you can elect to receive strongly typed events:

```csharp
pusher.GetEventSubscription<SomeDataStructure>().EventEmitted += (sender, evt)
	{
		// evt.Data is SomeDataStructure
		Debug.WriteLine(evt.Data.Id);
	};
```
