import { Customer } from "./customer.model";
import { EditorComponent } from "../shared";
import {  CustomerDelete, CustomerEdit, CustomerAdd } from "./customer.actions";

const template = require("./customer-edit-embed.component.html");
const styles = require("./customer-edit-embed.component.scss");

export class CustomerEditEmbedComponent extends HTMLElement {
    constructor() {
        super();
        this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return [
            "customer",
            "customer-id"
        ];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this._bind();
        this._setEventListeners();
    }
    
    private async _bind() {
        this._titleElement.textContent = this.customer ? "Edit Customer": "Create Customer";

        if (this.customer) {                
            this._nameInputElement.value = this.customer.name;  
        } else {
            this._deleteButtonElement.style.display = "none";
        }     
    }

    private _setEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._deleteButtonElement.addEventListener("click", this.onDelete);
    }

    private disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
        this._deleteButtonElement.removeEventListener("click", this.onDelete);
    }

    public onSave() {
        const customer = {
            id: this.customer != null ? this.customer.id : null,
            name: this._nameInputElement.value
        } as Customer;
        
        this.dispatchEvent(new CustomerAdd(customer));            
    }

    public onDelete() {        
        const customer = {
            id: this.customer != null ? this.customer.id : null,
            name: this._nameInputElement.value
        } as Customer;

        this.dispatchEvent(new CustomerDelete(customer));         
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "customer-id":
                this.customerId = newValue;
                break;
            case "customer":
                this.customer = JSON.parse(newValue);
                if (this.parentNode) {
                    this.customerId = this.customer.id;
                    this._nameInputElement.value = this.customer.name != undefined ? this.customer.name : "";
                    this._titleElement.textContent = this.customerId ? "Edit Customer" : "Create Customer";
                }
                break;
        }           
    }

    public customerId: any;
    public customer: Customer;
    
    private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".customer-name") as HTMLInputElement;}
}

customElements.define(`ce-customer-edit-embed`,CustomerEditEmbedComponent);
