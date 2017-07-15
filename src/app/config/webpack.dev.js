var webpackMerge = require('webpack-merge');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var commonConfig = require('./webpack.common.js');

const path = require('path');
const rootDir = __dirname;

module.exports = webpackMerge(commonConfig, {

devtool: 'cheap-module-eval-source-map',

output: {
    path: path.resolve(rootDir, 'dist'),
    filename: '[name].js',
        chunkFilename: '[id].chunk.js'
    },

    plugins: [
        new ExtractTextPlugin('[name].css')
    ],

    devServer: {
        historyApiFallback: true,
        stats: 'minimal'
    }
});
