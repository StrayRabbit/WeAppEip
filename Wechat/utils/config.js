// var API_BASE = 'http://134.175.49.139/';
var API_BASE = 'https://www.bianchengcn.com/';

const CONFIG = {
    API_URL: {
        API_BASE: API_BASE,

        GET_INDEX: API_BASE+'api/banner',
        GET_NEWS: API_BASE +'api/news/getItems',
        GET_Activities: API_BASE +'api/news/getItems',
        GET_ARTICLE: API_BASE + 'api/news/getItem/',
    }
}

module.exports = CONFIG;