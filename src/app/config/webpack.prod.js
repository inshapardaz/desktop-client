var webpackMerge = require('webpack-merge');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var commonConfig = require('./webpack.common.js');
var CopyWebpackPlugin = require('copy-webpack-plugin');
var UglifyJSPlugin = require('uglifyjs-webpack-plugin');

const path = require('path');
const rootDir = path.resolve(__dirname, '..');

module.exports = webpackMerge(commonConfig, {
output: {
    path: path.resolve(rootDir, ''),
    filename: '[name].js',
        chunkFilename: '[id].chunk.js'
    },

    plugins: [
        new UglifyJSPlugin(),
        new CopyWebpackPlugin([{
            from: 'src/prod.json',
            to: './env.json'
        }]),
    ]
});
