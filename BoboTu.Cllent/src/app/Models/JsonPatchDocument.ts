 export class PatchOperation{
    constructor(op:string, path:string, value){
        this.op = op;
        this.path = path;
        this.value = value;
    }
    op:string
    path:string
    value:any
}

export class JsonPatchDocument{
    operations:Array<PatchOperation> = new Array<PatchOperation>();

    AddOperation(operation: PatchOperation){
        this.operations.push(operation);
    }
}