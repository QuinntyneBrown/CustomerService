import { Customer } from "./customer.model";

export const customerActions = {
    ADD: "[Customer] Add",
    EDIT: "[Customer] Edit",
    DELETE: "[Customer] Delete",
    CUSTOMERS_CHANGED: "[Customer] Customers Changed"
};

export class CustomerEvent extends CustomEvent {
    constructor(eventName:string, customer: Customer) {
        super(eventName, {
            bubbles: true,
            cancelable: true,
            detail: { customer }
        });
    }
}

export class CustomerAdd extends CustomerEvent {
    constructor(customer: Customer) {
        super(customerActions.ADD, customer);        
    }
}

export class CustomerEdit extends CustomerEvent {
    constructor(customer: Customer) {
        super(customerActions.EDIT, customer);
    }
}

export class CustomerDelete extends CustomerEvent {
    constructor(customer: Customer) {
        super(customerActions.DELETE, customer);
    }
}

export class CustomersChanged extends CustomEvent {
    constructor(customers: Array<Customer>) {
        super(customerActions.CUSTOMERS_CHANGED, {
            bubbles: true,
            cancelable: true,
            detail: { customers }
        });
    }
}
