export class Customer { 
    public id:any;
    public name: string;
    public firstname: any;
    public lastname: any;
    public address: any;
    public city: any;
    public province: any;
    public postalCode: any;
    public emailAddress: any;
    public mobile: any;   
    public phoneNumber: any;

    public fromJSON(data: any): Customer {
        let customer = new Customer();
        customer.name = data.name;
        customer.firstname = data.firstname;
        customer.lastname = data.lastname;
        customer.address = data.address;
        customer.city = data.city;
        customer.province = data.province;
        customer.postalCode = data.postalCode;
        customer.emailAddress = data.emailAddress;
        customer.mobile = data.mobile;
        customer.phoneNumber = data.phoneNumber;
        return customer;
    }
}
