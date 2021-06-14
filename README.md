# Neu (mk 2)

Functional concurrency.

The goal:

```

struct MyType {

}

enum MyEnum {

}

interface IInterface {

}

extend MyType {

}

alias MyAlias = Thing

func foo() {

    ...
}

func foo() -> Int {

    return 0
}

///

task fooTask() {

    ...
}

task fooTask<T>() -> Result<T> {

    ...
}


///

await fooTask()

///

let a = async fooTask()
let b = async fooTask()

await a, b

///

actor MyActor {

    /// externally callable but actioned atomically
}

extend MyActor {

    action fooAction() {

    }
}
```