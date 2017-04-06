export class Customer { 
    public id:any;
    public name:string;

    public fromJSON(data: { name:string }): Customer {
        let customer = new Customer();
        customer.name = data.name;
        return customer;
    }
}
