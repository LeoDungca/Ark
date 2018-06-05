<template>
    <div>
        <v-content>
            <v-container fluid="" fill-height="">
                <v-layout align-center="" justify-center="" style="min-height: 70vh">
                    <v-flex xs12="" sm8="" md4="">
                        <v-card class="elevation-12">
                            <v-toolbar dark="" color="primary">
                                <v-toolbar-title>Write a comment</v-toolbar-title>
                            </v-toolbar>
                            <v-card-text class="pr-5 pl-5">
                                <v-alert color="error" icon="warning" value="true" v-show="modelstate['Error']">
                                    {{ modelstate['Error'] }}
                                </v-alert>
                                <v-form @submit.prevent="submitComment">
                                    <v-text-field label="Name" name="Name" ref="name" v-model="input.name" :error-messages="modelstate['Name']"
                                                  :blur="clearModelState"
                                                  required=""
                                                  :rules="[(v) => v.length <= 12 || 'Max 12 characters']">
                                    </v-text-field>
                                    <v-text-field multi-line="" name="Comment" label="Comment"
                                                  v-model="input.comment"
                                                  :error-messages="modelstate['Comment']"
                                                  :rules="[(v) => v.length <= 250 || 'Max 250 characters']"
                                                  :counter="250">
                                    </v-text-field>
                                    <br></br>
                                    <v-btn block="" color="gray" type="submit">Send</v-btn>
                                </v-form>
                            </v-card-text>
                        </v-card>
                    </v-flex>
                </v-layout>
            </v-container>
        </v-content>
    </div>
</template>

<script src="./comment.ts"></script>