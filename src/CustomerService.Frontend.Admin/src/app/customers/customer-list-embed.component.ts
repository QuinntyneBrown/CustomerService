import { Customer } from "./customer.model";

const template = require("./customer-list-embed.component.html");
const styles = require("./customer-list-embed.component.scss");

export class CustomerListEmbedComponent extends HTMLElement {
    constructor(
        private _document: Document = document
    ) {
        super();
    }


    static get observedAttributes() {
        return [
            "customers"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private async _bind() {        
        for (let i = 0; i < this.customers.length; i++) {
            let el = this._document.createElement(`ce-customer-item-embed`);
            el.setAttribute("entity", JSON.stringify(this.customers[i]));
            this.appendChild(el);
        }    
    }

    customers:Array<Customer> = [];

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "customers":
                this.customers = JSON.parse(newValue);
                if (this.parentElement)
                    this.connectedCallback();
                break;
        }
    }
}

customElements.define("ce-customer-list-embed", CustomerListEmbedComponent);
