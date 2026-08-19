const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = (env, argv) => ({
  entry: {
    'time-tracker': './src/time-tracker/index.tsx',
    'settings': './src/settings/index.tsx',
    'report': './src/report/index.tsx',
    'my-report': './src/my-report/index.tsx',
    'user-utilization-report': './src/user-utilization-report/index.tsx',
  },
  output: {
    filename: '[name]/index.js',
    path: path.resolve(__dirname, 'dist'),
    clean: true,
  },
  resolve: {
    extensions: ['.ts', '.tsx', '.js'],
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: [
          {
            loader: 'ts-loader',
            options: {
              onlyCompileBundledFiles: true,
            },
          },
        ],
        exclude: /node_modules/,
      },
      {
        test: /\.css$/,
        use: ['style-loader', 'css-loader'],
      },
    ],
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: './src/time-tracker/index.html',
      filename: 'time-tracker/index.html',
      chunks: ['time-tracker'],
    }),
    new HtmlWebpackPlugin({
      template: './src/settings/index.html',
      filename: 'settings/index.html',
      chunks: ['settings'],
    }),
    new HtmlWebpackPlugin({
      template: './src/report/index.html',
      filename: 'report/index.html',
      chunks: ['report'],
    }),
    new HtmlWebpackPlugin({
      template: './src/my-report/index.html',
      filename: 'my-report/index.html',
      chunks: ['my-report'],
    }),
    new HtmlWebpackPlugin({
      template: './src/user-utilization-report/index.html',
      filename: 'user-utilization-report/index.html',
      chunks: ['user-utilization-report'],
    }),
  ],
  devtool: argv.mode === 'development' ? 'inline-source-map' : false,
});
