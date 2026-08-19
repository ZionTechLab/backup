const fs = require('fs');

let content = fs.readFileSync('webpack.config.js', 'utf8');

content = content.replace(
  "use: 'ts-loader',",
  `use: [
          {
            loader: 'ts-loader',
            options: {
              onlyCompileBundledFiles: true,
            },
          },
        ],`
);

fs.writeFileSync('webpack.config.js', content);
console.log('webpack.config.js patched');
