import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        CloudstaffMenu: require('../navmenu/navmenu.vue')
    }
})
export default class AppComponent extends Vue {

}
