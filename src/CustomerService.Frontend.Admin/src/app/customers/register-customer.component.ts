import { CustomerService } from "./customer.service";

const template = require("./register-customer.component.html");
const styles = require("./register-customer.component.scss");

export class RegisterCustomerComponent extends HTMLElement {
    constructor(
        private _customerService: CustomerService = CustomerService.Instance
    ) {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {

    }

    private _setEventListeners() {

    }

    disconnectedCallback() {

    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

customElements.define(`ce-register-customer`,RegisterCustomerComponent);