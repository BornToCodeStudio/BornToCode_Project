import vue from "@vitejs/plugin-vue";

export default {
    server: {
        url: "https://borntocode-api.onrender.com",
        port: 3000,
    },
    preview: {
        url: "http://localhost:8000",
        port: 3000,
    },
    plugins: [
        vue({
            template: {
                transformAssetUrls: {
                    base: null,
                    includeAbsolute: false,
                },
            },
        }),
    ],
    resolve: {
        alias: {
            vue: 'vue/dist/vue.esm-bundler.js',
        },
    },
}