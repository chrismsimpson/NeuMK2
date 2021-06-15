# Neu (mk 2)

Functional concurrency.

The goal:

## Types

```
struct MyType {

}
```

```
enum MyEnum {

    case myCase
}
```

## Interfaces

```
interface IInterface {

}
```

## Implementation

```
extend MyType {

}
```

```
extend MyItem: ISomeInterface {

}
```

## Aliasing

```
alias MyAlias = Thing
```

## Functions

```
func foo() {

    ...
}
```

```
func foo() -> Int {

    return 0
}
```

## Operators

`and` instead of `&&`, `or` instead of `||`

```
if a and b {

}
else if b or c {

}
```

v1.0 will have backward compatibility with a warning.

## Concurrency

```
task fooTask() {

    ...
}
```

```
task fooTask<T>() -> Result<T> {

    ...
}
```

```
await fooTask()
```

```
let a = async fooTask()
let b = async fooTask()

await a, b
```

```
extend MyType {

    func someFunction() {

        async someAsyncFunc()
    }

    // ^ two errors at return call site:
    //     - Failure to await all tasks
    //     - Incorrectly declared async
    //       body as func instead of task
}
```

## Concurrency (Actors)

```
actor MyActor {

    /// externally callable but actioned atomically
}

extend MyActor {

    action fooAction() {

    }
}
```
```
extend SomeExternalType {

    task callTheActor() {

        // must await as asynchronously actioned

        await localActor.fooAction() 
    }
}
```



# Detailed

## Control Flow

### IfStatement

```
if true {

}
```

```
if true {

}
else {

}
```

### TryCatch

```
do {
    let n = try someThrowableFunc()
}
catch {

}
```

### 

## Attributes

```
#yolo
func myFunc() {

}
```

## 