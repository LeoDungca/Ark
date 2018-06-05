import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import http from 'axios';

interface Comment {    
    name: string;
    comment: string;
}

@Component
export default class CommentComponent extends Vue {
    input: Comment = { name: "", comment: "" }
    modelstate: object[];

    clearData(): void {
        this.input.name = ''
        this.input.comment = ''
    }

    clearModelState(): void {
        for(var error in this.modelstate) {
            delete this.modelstate[error];
        }
    }

    //submitComment(): void {
    //    console.log(this.input);
    //    var url = '/api/SampleData/SubmitComment';
    //    http.post(url, this.input)
    //        .then(function (response) {
    //            alert(response);
    //        })
    //        .catch(function (error) {
    //            console.log(error);
    //        });
    //}  
}

