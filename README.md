# Interview Web API

A .NET 8 Web API starter with Swagger UI, configured outbound HTTP clients, structured logging, and an in-memory work-item repository.

## Run locally

```sh
dotnet run
```

In Development, Swagger UI is available at `/swagger`.

## Work items

Create a work item with `POST /api/work-items`:

```json
{
  "name": "Prepare interview exercise",
  "description": "A sample item"
}
```

The API responds with `201 Created` and a `Location` header. Retrieve it with `GET /api/work-items/{id}`. Data is held in memory and is lost when the application stops.

Sample requests are in `WebApplication1.http`.

## Outbound APIs

`ExternalApi` and `ExternalApi2` are configured in `appsettings.json`. Replace their placeholder base addresses with the desired API URLs. The corresponding singleton services reuse their keyed `HttpClient` instances.