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
            this._firstnameInputElement.value = this.customer.firstname;
            this._lastnameInputElement.value = this.customer.lastname;
            this._emailAddressInputElement.value = this.customer.emailAddress;
            this._cityInputElement.value = this.customer.city;
            this._addressInputElement.value = this.customer.address;
            this._provinceInputElement.value = this.customer.province;
            this._phoneNumberInputElement.value = this.customer.phoneNumber;
            this._mobileInputElement.value = this.customer.mobile;            
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
            name: this._nameInputElement.value,
            firstname: this._firstnameInputElement.value,
            lastname: this._lastnameInputElement.value,
            emailAddress: this._emailAddressInputElement.value,
            address: this._addressInputElement.value,
            city: this._cityInputElement.value,
            province: this._provinceInputElement.value,
            postalCode: this._postalCodeInputElement.value,
            phoneNumber: this._phoneNumberInputElement.value,
            mobile: this._mobileInputElement.value
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
                    this._firstnameInputElement.value = this.customer.firstname != undefined ? this.customer.firstname : "";
                    this._lastnameInputElement.value = this.customer.lastname != undefined ? this.customer.lastname : "";
                    this._emailAddressInputElement.value = this.customer.emailAddress != undefined ? this.customer.emailAddress: "";
                    this._cityInputElement.value = this.customer.city != undefined ? this.customer.city : "";
                    this._addressInputElement.value = this.customer.address != undefined ? this.customer.address: "";
                    this._provinceInputElement.value = this.customer.province != undefined ? this.customer.province : "";
                    this._phoneNumberInputElement.value = this.customer.phoneNumber != undefined ? this.customer.phoneNumber : "";
                    this._mobileInputElement.value = this.customer.mobile != undefined ? this.customer.mobile : "";
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
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".customer-name") as HTMLInputElement; }
    private get _firstnameInputElement(): HTMLInputElement { return this.querySelector(".customer-firstname") as HTMLInputElement; }
    private get _lastnameInputElement(): HTMLInputElement { return this.querySelector(".customer-lastname") as HTMLInputElement; }
    private get _addressInputElement(): HTMLInputElement { return this.querySelector(".customer-address") as HTMLInputElement; }
    private get _cityInputElement(): HTMLInputElement { return this.querySelector(".customer-city") as HTMLInputElement; }
    private get _provinceInputElement(): HTMLInputElement { return this.querySelector(".customer-province") as HTMLInputElement; }
    private get _postalCodeInputElement(): HTMLInputElement { return this.querySelector(".customer-postal-code") as HTMLInputElement; }
    private get _phoneNumberInputElement(): HTMLInputElement { return this.querySelector(".customer-phone-number") as HTMLInputElement; }
    private get _mobileInputElement(): HTMLInputElement { return this.querySelector(".customer-mobile") as HTMLInputElement; }
    private get _emailAddressInputElement(): HTMLInputElement { return this.querySelector(".customer-email-address") as HTMLInputElement; }
}

customElements.define(`ce-customer-edit-embed`,CustomerEditEmbedComponent);
