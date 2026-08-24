# Taller Práctico de Arquitectura Hexagonal

**Nombre:** Juan Camilo Duarte

## Descripción

Sistema para procesar pedidos de café en una tostaduría de café de especialidad, implementado siguiendo Arquitectura Hexagonal (Ports & Adapters) en C# / .NET 8.

## Estructura del proyecto

- **Domain**: Entidades (`Order`, `CoffeeBean`, `BrewingMethod`), excepciones de dominio (`BusinessException`) y servicios.
- **Application**: Casos de uso (`ProcessCoffeeOrderUseCase`) y puertos de entrada(`IProcessCoffeeOrderUseCase`) y salida (`ICoffeeBeanPort`, `IBrewingMethodPort`, `IOrderRepositoryPort`).
- **Infrastructure**: Adaptadores secundarios en memoria (`InMemoryCoffeeBeanAdapter`, `InMemoryBrewingMethodAdapter`, `InMemoryOrderAdapter`).
- **API**: Proyecto ASP.NET Core Web API — adaptador primario (`OrderController`) y ensamblaje de dependencias (`Program.cs`).

---

## Misión 5: Reflexión Arquitectónica

### 1. Si el día de mañana la tostaduría decide cambiar la base de datos en memoria por PostgreSQL, ¿qué carpetas o clases de tu proyecto tendrías que modificar y cuáles se mantendrían intactas?

Los cambios se realizan solo en la capa Infrastructure. Habría que crear nuevas implementaciones de los puertos de salida que usen Entity Framework Core u otro ORM en lugar de diccionarios en memoria. Dado que un ORM suele exigir clases de entidad con constructor vacío y setters públicos, probablemente sea necesario introducir clases de entidad de persistencia junto con un mapper que traduzca entre esa entidad y con modelo correspondiente. También habría que actualizar el registro de dependencias en `Program.cs`, reemplazando los adaptadores in-memory por los nuevos adaptadores de PostgreSQL.

Las capas Domain y Application se mantendrían completamente intactas. No se modificaría nada de las entidades, las validaciones, los puertos ni la lógica de los casos de uno, ya que estas capas no conocen ni dependen de ningún detalle de persistencia, solo dependen de las interfaces que ya existen.

### 2. ¿Por qué es importante que el ProcessCoffeeOrderUseCase no conozca la existencia del InMemoryInventoryAdapter?

Es importante porque el caso de uso depende de una abstracción, no de una implementación concreta, siguiendo el Principio de Inversión de Dependencias. Si `ProcessCoffeeOrderUseCase` conociera directamente `InMemoryInventoryAdapter`, la capa `Application` pasaría a depender de `Infrastructure`, invirtiendo el flujo de dependencias que la arquitectura hexagonal exige. Además, esto permite testear los casos de uso de forma aislada usando un mock de la interfaz, sin necesitar una implementación real, y permite cambiar la tecnología sin tocar la lógica de negocio.
