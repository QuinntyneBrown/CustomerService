import { fetch } from "../utilities";
import { Customer } from "./customer.model";

export class CustomerService {
    constructor(private _fetch = fetch) { }

    private static _instance: CustomerService;

    public static get Instance() {
        this._instance = this._instance || new CustomerService();
        return this._instance;
    }

    public get(): Promise<Array<Customer>> {
        return this._fetch({ url: "/api/customer/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { customers: Array<Customer> }).customers;
        });
    }

    public getById(id): Promise<Customer> {
        return this._fetch({ url: `/api/customer/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { customer: Customer }).customer;
        });
    }

    public add(customer) {
        return this._fetch({ url: `/api/customer/add`, method: "POST", data: { customer }, authRequired: true  });
    }

    public register(customer) {
        return this._fetch({ url: `/api/customer/register`, method: "POST", data: { customer }, authRequired: true });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/customer/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }    
}