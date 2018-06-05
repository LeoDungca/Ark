import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios'

interface User {
    email: string;
    password: string;
}

@Component
export default class LoginComponent extends Vue {

    input: User = { email: "", password: "" }

    
    submit(): void {
        axios.post('/Account/Login', this.input)
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }
    
}
