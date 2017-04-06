import { CustomerAdd, CustomerDelete, CustomerEdit, customerActions } from "./customer.actions";
import { Customer } from "./customer.model";

const template = require("./customer-master-detail.component.html");
const styles = require("./customer-master-detail.component.scss");

export class CustomerMasterDetailComponent extends HTMLElement {
    constructor() {
        super();
        this.onCustomerAdd = this.onCustomerAdd.bind(this);
        this.onCustomerEdit = this.onCustomerEdit.bind(this);
        this.onCustomerDelete = this.onCustomerDelete.bind(this);
    }

    static get observedAttributes () {
        return [
            "customers"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {
        this.customerListElement.setAttribute("customers", JSON.stringify(this.customers));
    }

    private _setEventListeners() {
        this.addEventListener(customerActions.ADD, this.onCustomerAdd);
        this.addEventListener(customerActions.EDIT, this.onCustomerEdit);
        this.addEventListener(customerActions.DELETE, this.onCustomerDelete);
    }

    disconnectedCallback() {
        this.removeEventListener(customerActions.ADD, this.onCustomerAdd);
        this.removeEventListener(customerActions.EDIT, this.onCustomerEdit);
        this.removeEventListener(customerActions.DELETE, this.onCustomerDelete);
    }

    public onCustomerAdd(e) {

        const index = this.customers.findIndex(o => o.id == e.detail.customer.id);
        const indexBaseOnUniqueIdentifier = this.customers.findIndex(o => o.name == e.detail.customer.name);

        if (index > -1 && e.detail.customer.id != null) {
            this.customers[index] = e.detail.customer;
        } else if (indexBaseOnUniqueIdentifier > -1) {
            for (var i = 0; i < this.customers.length; ++i) {
                if (this.customers[i].name == e.detail.customer.name)
                    this.customers[i] = e.detail.customer;
            }
        } else {
            this.customers.push(e.detail.customer);
        }
        
        this.customerListElement.setAttribute("customers", JSON.stringify(this.customers));
        this.customerEditElement.setAttribute("customer", JSON.stringify(new Customer()));
    }

    public onCustomerEdit(e) {
        this.customerEditElement.setAttribute("customer", JSON.stringify(e.detail.customer));
    }

    public onCustomerDelete(e) {
        if (e.detail.customer.Id != null && e.detail.customer.Id != undefined) {
            this.customers.splice(this.customers.findIndex(o => o.id == e.detail.optionId), 1);
        } else {
            for (var i = 0; i < this.customers.length; ++i) {
                if (this.customers[i].name == e.detail.customer.name)
                    this.customers.splice(i, 1);
            }
        }

        this.customerListElement.setAttribute("customers", JSON.stringify(this.customers));
        this.customerEditElement.setAttribute("customer", JSON.stringify(new Customer()));
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "customers":
                this.customers = JSON.parse(newValue);

                if (this.parentNode)
                    this.connectedCallback();

                break;
        }
    }

    public get value(): Array<Customer> { return this.customers; }

    private customers: Array<Customer> = [];
    public customer: Customer = <Customer>{};
    public get customerEditElement(): HTMLElement { return this.querySelector("ce-customer-edit-embed") as HTMLElement; }
    public get customerListElement(): HTMLElement { return this.querySelector("ce-customer-list-embed") as HTMLElement; }
}

customElements.define(`ce-customer-master-detail`,CustomerMasterDetailComponent);
