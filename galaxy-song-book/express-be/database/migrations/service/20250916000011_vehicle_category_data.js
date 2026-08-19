exports.up = async function(knex) {
  const data = [
    { tenantId:1,companyId:1, id: 1, categoryType: 10, value: 'Toyota', active: 1},
    { tenantId:1,companyId:1, id: 2, categoryType: 10, value: 'Honda', active: 1},
    { tenantId:1,companyId:1, id: 3, categoryType: 10, value: 'Nissan', active: 1},
    { tenantId:1,companyId:1, id: 4, categoryType: 10, value: 'Suzuki', active: 1},
    { tenantId:1,companyId:1, id: 5, categoryType: 10, value: 'Mazda', active: 1},
    { tenantId:1,companyId:1, id: 6, categoryType: 10, value: 'Mitsubishi', active: 1},
    { tenantId:1,companyId:1, id: 7, categoryType: 10, value: 'Subaru', active: 1},
    { tenantId:1,companyId:1, id: 8, categoryType: 10, value: 'Lexus', active: 1},
    { tenantId:1,companyId:1, id: 9, categoryType: 10, value: 'Isuzu', active: 1},
    { tenantId:1,companyId:1, id: 10, categoryType: 10, value: 'Hyundai', active: 1},
    { tenantId:1,companyId:1, id: 11, categoryType: 10, value: 'Kia', active: 1},
    { tenantId:1,companyId:1, id: 12, categoryType: 10, value: 'BMW', active: 1},
    { tenantId:1,companyId:1, id: 13, categoryType: 10, value: 'Mercedes-Benz', active: 1},
    { tenantId:1,companyId:1, id: 14, categoryType: 10, value: 'Audi', active: 1},
    { tenantId:1,companyId:1, id: 15, categoryType: 10, value: 'Volkswagen', active: 1},
    { tenantId:1,companyId:1, id: 16, categoryType: 10, value: 'Porsche', active: 1},
    { tenantId:1,companyId:1, id: 17, categoryType: 10, value: 'Ford', active: 1},
    { tenantId:1,companyId:1, id: 18, categoryType: 10, value: 'Tesla', active: 1},
    { tenantId:1,companyId:1, id: 19, categoryType: 10, value: 'Renault', active: 1},
    { tenantId:1,companyId:1, id: 20, categoryType: 10, value: 'Peugeot', active: 1},
    { tenantId:1,companyId:1, id: 21, categoryType: 10, value: 'Fiat', active: 1},
    { tenantId:1,companyId:1, id: 22, categoryType: 10, value: 'Land Rover', active: 1},
    { tenantId:1,companyId:1, id: 23, categoryType: 10, value: 'Volvo', active: 1},
    { tenantId:1,companyId:1, id: 24, categoryType: 10, value: 'BYD', active: 1},
    { tenantId:1,companyId:1, id: 25, categoryType: 10, value: 'Chery', active: 1},

    { tenantId:1,companyId:1, id: 26, categoryType: 20, parentId: 1, value: 'Toyota Corolla', active: 1},
    { tenantId:1,companyId:1, id: 35, categoryType: 20, parentId: 1, value: 'Toyota Aqua (Prius C)', active: 1},
    { tenantId:1,companyId:1, id: 36, categoryType: 20, parentId: 1, value: 'Toyota Camry', active: 1},
    { tenantId:1,companyId:1, id: 37, categoryType: 20, parentId: 1, value: 'Toyota Hilux', active: 1},
    { tenantId:1,companyId:1, id: 38, categoryType: 20, parentId: 1, value: 'Toyota Land Cruiser', active: 1},
    { tenantId:1,companyId:1, id: 39, categoryType: 20, parentId: 1, value: 'Toyota Yaris', active: 1},
    { tenantId:1,companyId:1, id: 40, categoryType: 20, parentId: 1, value: 'Toyota RAV4', active: 1},
    { tenantId:1,companyId:1, id: 41, categoryType: 20, parentId: 1, value: 'Toyota Prius', active: 1},

  



    // Grades (categoryType: 30, parentId: modelId)
    // Corolla
    { tenantId:1,companyId:1, id: 27, categoryType: 30, parentId: 26, value: 'L', active: 1},
    { tenantId:1,companyId:1, id: 28, categoryType: 30, parentId: 26, value: 'L', active: 1},
    { tenantId:1,companyId:1, id: 29, categoryType: 30, parentId: 26, value: 'LE', active: 1},
    { tenantId:1,companyId:1, id: 30, categoryType: 30, parentId: 26, value: 'SE', active: 1},
    { tenantId:1,companyId:1, id: 31, categoryType: 30, parentId: 26, value: 'XSE', active: 1},
    { tenantId:1,companyId:1, id: 32, categoryType: 30, parentId: 26, value: 'XLE', active: 1},
    { tenantId:1,companyId:1, id: 33, categoryType: 30, parentId: 26, value: 'G', active: 1},
    { tenantId:1,companyId:1, id: 34, categoryType: 30, parentId: 26, value: 'Luxcel', active: 1},
    // Aqua (Prius C)
    { tenantId:1,companyId:1, id: 42, categoryType: 30, parentId: 35, value: 'L', active: 1},
    { tenantId:1,companyId:1, id: 43, categoryType: 30, parentId: 35, value: 'S', active: 1},
    { tenantId:1,companyId:1, id: 44, categoryType: 30, parentId: 35, value: 'G', active: 1},
    { tenantId:1,companyId:1, id: 45, categoryType: 30, parentId: 35, value: 'G Black Soft Leather Selection', active: 1},
    // Camry
    { tenantId:1,companyId:1, id: 46, categoryType: 30, parentId: 36, value: 'LE', active: 1},
    { tenantId:1,companyId:1, id: 47, categoryType: 30, parentId: 36, value: 'SE', active: 1},
    { tenantId:1,companyId:1, id: 48, categoryType: 30, parentId: 36, value: 'XLE', active: 1},
    { tenantId:1,companyId:1, id: 49, categoryType: 30, parentId: 36, value: 'XSE', active: 1},
    { tenantId:1,companyId:1, id: 50, categoryType: 30, parentId: 36, value: 'Nightshade', active: 1},
    // Hilux
    { tenantId:1,companyId:1, id: 51, categoryType: 30, parentId: 37, value: 'Single Cab', active: 1},
    { tenantId:1,companyId:1, id: 52, categoryType: 30, parentId: 37, value: 'Double Cab', active: 1},
    { tenantId:1,companyId:1, id: 53, categoryType: 30, parentId: 37, value: 'G', active: 1},
    { tenantId:1,companyId:1, id: 54, categoryType: 30, parentId: 37, value: 'Revo', active: 1},
    { tenantId:1,companyId:1, id: 55, categoryType: 30, parentId: 37, value: 'Invincible', active: 1},
    // Land Cruiser
    { tenantId:1,companyId:1, id: 56, categoryType: 30, parentId: 38, value: 'GX', active: 1},
    { tenantId:1,companyId:1, id: 57, categoryType: 30, parentId: 38, value: 'VX', active: 1},
    { tenantId:1,companyId:1, id: 58, categoryType: 30, parentId: 38, value: 'ZX', active: 1},
    { tenantId:1,companyId:1, id: 59, categoryType: 30, parentId: 38, value: 'GR Sport', active: 1},
    // Yaris
    { tenantId:1,companyId:1, id: 60, categoryType: 30, parentId: 39, value: 'L', active: 1},
    { tenantId:1,companyId:1, id: 61, categoryType: 30, parentId: 39, value: 'LE', active: 1},
    { tenantId:1,companyId:1, id: 62, categoryType: 30, parentId: 39, value: 'SE', active: 1},
    { tenantId:1,companyId:1, id: 63, categoryType: 30, parentId: 39, value: 'XLE', active: 1},
    // RAV4
    { tenantId:1,companyId:1, id: 64, categoryType: 30, parentId: 40, value: 'LE', active: 1},
    { tenantId:1,companyId:1, id: 65, categoryType: 30, parentId: 40, value: 'XLE', active: 1},
    { tenantId:1,companyId:1, id: 66, categoryType: 30, parentId: 40, value: 'Adventure', active: 1},
    { tenantId:1,companyId:1, id: 67, categoryType: 30, parentId: 40, value: 'Limited', active: 1},
    { tenantId:1,companyId:1, id: 68, categoryType: 30, parentId: 40, value: 'TRD Off-Road', active: 1},
    // Prius
    { tenantId:1,companyId:1, id: 69, categoryType: 30, parentId: 41, value: 'L Eco', active: 1},
    { tenantId:1,companyId:1, id: 70, categoryType: 30, parentId: 41, value: 'LE', active: 1},
    { tenantId:1,companyId:1, id: 71, categoryType: 30, parentId: 41, value: 'XLE', active: 1},
    { tenantId:1,companyId:1, id: 72, categoryType: 30, parentId: 41, value: 'Limited', active: 1},


    // Honda Models
    { tenantId:1,companyId:1, id: 73, categoryType: 20, parentId: 2, value: 'Honda Civic', active: 1},
    { tenantId:1,companyId:1, id: 74, categoryType: 20, parentId: 2, value: 'Honda Accord', active: 1},
    { tenantId:1,companyId:1, id: 75, categoryType: 20, parentId: 2, value: 'Honda Fit', active: 1},
    { tenantId:1,companyId:1, id: 76, categoryType: 20, parentId: 2, value: 'Honda CR-V', active: 1},
    { tenantId:1,companyId:1, id: 77, categoryType: 20, parentId: 2, value: 'Honda HR-V', active: 1},
    { tenantId:1,companyId:1, id: 78, categoryType: 20, parentId: 2, value: 'Honda City', active: 1},
    { tenantId:1,companyId:1, id: 79, categoryType: 20, parentId: 2, value: 'Honda Freed', active: 1},

    // Honda Civic Grades
    { tenantId:1,companyId:1, id: 80, categoryType: 30, parentId: 73, value: 'LX', active: 1},
    { tenantId:1,companyId:1, id: 81, categoryType: 30, parentId: 73, value: 'EX', active: 1},
    { tenantId:1,companyId:1, id: 82, categoryType: 30, parentId: 73, value: 'EX-T', active: 1},
    { tenantId:1,companyId:1, id: 83, categoryType: 30, parentId: 73, value: 'EX-L', active: 1},
    { tenantId:1,companyId:1, id: 84, categoryType: 30, parentId: 73, value: 'Touring', active: 1},
    { tenantId:1,companyId:1, id: 85, categoryType: 30, parentId: 73, value: 'Sport', active: 1},

    // Honda Accord Grades
    { tenantId:1,companyId:1, id: 86, categoryType: 30, parentId: 74, value: 'LX', active: 1},
    { tenantId:1,companyId:1, id: 87, categoryType: 30, parentId: 74, value: 'Sport', active: 1},
    { tenantId:1,companyId:1, id: 88, categoryType: 30, parentId: 74, value: 'EX-L', active: 1},
    { tenantId:1,companyId:1, id: 89, categoryType: 30, parentId: 74, value: 'Touring', active: 1},

    // Honda Fit Grades
    { tenantId:1,companyId:1, id: 90, categoryType: 30, parentId: 75, value: 'LX', active: 1},
    { tenantId:1,companyId:1, id: 91, categoryType: 30, parentId: 75, value: 'EX', active: 1},
    { tenantId:1,companyId:1, id: 92, categoryType: 30, parentId: 75, value: 'EX-L', active: 1},
    { tenantId:1,companyId:1, id: 93, categoryType: 30, parentId: 75, value: 'Sport', active: 1},

    // Honda CR-V Grades
    { tenantId:1,companyId:1, id: 94, categoryType: 30, parentId: 76, value: 'LX', active: 1},
    { tenantId:1,companyId:1, id: 95, categoryType: 30, parentId: 76, value: 'EX', active: 1},
    { tenantId:1,companyId:1, id: 96, categoryType: 30, parentId: 76, value: 'EX-L', active: 1},
    { tenantId:1,companyId:1, id: 97, categoryType: 30, parentId: 76, value: 'Touring', active: 1},

    // Honda HR-V Grades
    { tenantId:1,companyId:1, id: 98, categoryType: 30, parentId: 77, value: 'LX', active: 1},
    { tenantId:1,companyId:1, id: 99, categoryType: 30, parentId: 77, value: 'EX', active: 1},
    { tenantId:1,companyId:1, id: 100, categoryType: 30, parentId: 77, value: 'EX-L', active: 1},
    { tenantId:1,companyId:1, id: 101, categoryType: 30, parentId: 77, value: 'Sport', active: 1},

    // Honda City Grades
    { tenantId:1,companyId:1, id: 102, categoryType: 30, parentId: 78, value: 'S', active: 1},
    { tenantId:1,companyId:1, id: 103, categoryType: 30, parentId: 78, value: 'V', active: 1},
    { tenantId:1,companyId:1, id: 104, categoryType: 30, parentId: 78, value: 'VX', active: 1},
    { tenantId:1,companyId:1, id: 105, categoryType: 30, parentId: 78, value: 'ZX', active: 1},

    // Honda Freed Grades
    { tenantId:1,companyId:1, id: 106, categoryType: 30, parentId: 79, value: 'G', active: 1},
    { tenantId:1,companyId:1, id: 107, categoryType: 30, parentId: 79, value: 'Crosstar', active: 1},
    { tenantId:1,companyId:1, id: 108, categoryType: 30, parentId: 79, value: 'Modulo X', active: 1},

    // Nissan Models
    { tenantId:1,companyId:1, id: 109, categoryType: 20, parentId: 3, value: 'Nissan Altima', active: 1},
    { tenantId:1,companyId:1, id: 110, categoryType: 20, parentId: 3, value: 'Nissan Sentra', active: 1},
    { tenantId:1,companyId:1, id: 111, categoryType: 20, parentId: 3, value: 'Nissan X-Trail', active: 1},
    { tenantId:1,companyId:1, id: 112, categoryType: 20, parentId: 3, value: 'Nissan Note', active: 1},
    { tenantId:1,companyId:1, id: 113, categoryType: 20, parentId: 3, value: 'Nissan Leaf', active: 1},
    { tenantId:1,companyId:1, id: 114, categoryType: 20, parentId: 3, value: 'Nissan Juke', active: 1},
    { tenantId:1,companyId:1, id: 115, categoryType: 20, parentId: 3, value: 'Nissan Serena', active: 1},

    // Nissan Altima Grades
    { tenantId:1,companyId:1, id: 116, categoryType: 30, parentId: 109, value: 'S', active: 1},
    { tenantId:1,companyId:1, id: 117, categoryType: 30, parentId: 109, value: 'SV', active: 1},
    { tenantId:1,companyId:1, id: 118, categoryType: 30, parentId: 109, value: 'SR', active: 1},
    { tenantId:1,companyId:1, id: 119, categoryType: 30, parentId: 109, value: 'SL', active: 1},
    { tenantId:1,companyId:1, id: 120, categoryType: 30, parentId: 109, value: 'Platinum', active: 1},

    // Nissan Sentra Grades
    { tenantId:1,companyId:1, id: 121, categoryType: 30, parentId: 110, value: 'S', active: 1},
    { tenantId:1,companyId:1, id: 122, categoryType: 30, parentId: 110, value: 'SV', active: 1},
    { tenantId:1,companyId:1, id: 123, categoryType: 30, parentId: 110, value: 'SR', active: 1},

    // Nissan X-Trail Grades
     {tenantId:1,companyId:1,id: 124, categoryType: 30, parentId: 111, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 125, categoryType: 30, parentId: 111, value: 'SV', active: 1},
     {tenantId:1,companyId:1,id: 126, categoryType: 30, parentId: 111, value: 'SL', active: 1},

    // Nissan Note Grades
     {tenantId:1,companyId:1,id: 127, categoryType: 30, parentId: 112, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 128, categoryType: 30, parentId: 112, value: 'X', active: 1},
     {tenantId:1,companyId:1,id: 129, categoryType: 30, parentId: 112, value: 'e-POWER', active: 1},

    // Nissan Leaf Grades
     {tenantId:1,companyId:1,id: 130, categoryType: 30, parentId: 113, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 131, categoryType: 30, parentId: 113, value: 'SV', active: 1},
     {tenantId:1,companyId:1,id: 132, categoryType: 30, parentId: 113, value: 'SL', active: 1},

    // Nissan Juke Grades
     {tenantId:1,companyId:1,id: 133, categoryType: 30, parentId: 114, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 134, categoryType: 30, parentId: 114, value: 'SV', active: 1},
     {tenantId:1,companyId:1,id: 135, categoryType: 30, parentId: 114, value: 'SL', active: 1},
     {tenantId:1,companyId:1,id: 136, categoryType: 30, parentId: 114, value: 'Nismo', active: 1},

    // Nissan Serena Grades
     {tenantId:1,companyId:1,id: 137, categoryType: 30, parentId: 115, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 138, categoryType: 30, parentId: 115, value: 'X', active: 1},
     {tenantId:1,companyId:1,id: 139, categoryType: 30, parentId: 115, value: 'Highway Star', active: 1},

    // Suzuki Models
     {tenantId:1,companyId:1,id: 140, categoryType: 20, parentId: 4, value: 'Suzuki Swift', active: 1},
     {tenantId:1,companyId:1,id: 141, categoryType: 20, parentId: 4, value: 'Suzuki Alto', active: 1},
     {tenantId:1,companyId:1,id: 142, categoryType: 20, parentId: 4, value: 'Suzuki Wagon R', active: 1},
     {tenantId:1,companyId:1,id: 143, categoryType: 20, parentId: 4, value: 'Suzuki Jimny', active: 1},
     {tenantId:1,companyId:1,id: 144, categoryType: 20, parentId: 4, value: 'Suzuki Vitara', active: 1},
     {tenantId:1,companyId:1,id: 145, categoryType: 20, parentId: 4, value: 'Suzuki Baleno', active: 1},
     {tenantId:1,companyId:1,id: 146, categoryType: 20, parentId: 4, value: 'Suzuki Ciaz', active: 1},

    // Suzuki Swift Grades
     {tenantId:1,companyId:1,id: 147, categoryType: 30, parentId: 140, value: 'GL', active: 1},
     {tenantId:1,companyId:1,id: 148, categoryType: 30, parentId: 140, value: 'GLX', active: 1},
     {tenantId:1,companyId:1,id: 149, categoryType: 30, parentId: 140, value: 'RS', active: 1},

    // Suzuki Alto Grades
     {tenantId:1,companyId:1,id: 150, categoryType: 30, parentId: 141, value: 'VX', active: 1},
     {tenantId:1,companyId:1,id: 151, categoryType: 30, parentId: 141, value: 'VXR', active: 1},
     {tenantId:1,companyId:1,id: 152, categoryType: 30, parentId: 141, value: 'AGS', active: 1},

    // Suzuki Wagon R Grades
     {tenantId:1,companyId:1,id: 153, categoryType: 30, parentId: 142, value: 'VXR', active: 1},
     {tenantId:1,companyId:1,id: 154, categoryType: 30, parentId: 142, value: 'VXL', active: 1},

    // Suzuki Jimny Grades
     {tenantId:1,companyId:1,id: 155, categoryType: 30, parentId: 143, value: 'GA', active: 1},
     {tenantId:1,companyId:1,id: 156, categoryType: 30, parentId: 143, value: 'GL', active: 1},
     {tenantId:1,companyId:1,id: 157, categoryType: 30, parentId: 143, value: 'GLX', active: 1},

    // Suzuki Vitara Grades
     {tenantId:1,companyId:1,id: 158, categoryType: 30, parentId: 144, value: 'GL+', active: 1},
     {tenantId:1,companyId:1,id: 159, categoryType: 30, parentId: 144, value: 'GLX', active: 1},

    // Suzuki Baleno Grades
     {tenantId:1,companyId:1,id: 160, categoryType: 30, parentId: 145, value: 'GL', active: 1},
     {tenantId:1,companyId:1,id: 161, categoryType: 30, parentId: 145, value: 'GLX', active: 1},

    // Suzuki Ciaz Grades
     {tenantId:1,companyId:1,id: 162, categoryType: 30, parentId: 146, value: 'Manual', active: 1},
     {tenantId:1,companyId:1,id: 163, categoryType: 30, parentId: 146, value: 'Automatic', active: 1},

    // Mazda Models
     {tenantId:1,companyId:1,id: 164, categoryType: 20, parentId: 5, value: 'Mazda 2', active: 1},
     {tenantId:1,companyId:1,id: 165, categoryType: 20, parentId: 5, value: 'Mazda 3', active: 1},
     {tenantId:1,companyId:1,id: 166, categoryType: 20, parentId: 5, value: 'Mazda 6', active: 1},
     {tenantId:1,companyId:1,id: 167, categoryType: 20, parentId: 5, value: 'Mazda CX-3', active: 1},
     {tenantId:1,companyId:1,id: 168, categoryType: 20, parentId: 5, value: 'Mazda CX-5', active: 1},
     {tenantId:1,companyId:1,id: 169, categoryType: 20, parentId: 5, value: 'Mazda CX-9', active: 1},

    // Mazda 2 Grades
     {tenantId:1,companyId:1,id: 170, categoryType: 30, parentId: 164, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 171, categoryType: 30, parentId: 164, value: 'Touring', active: 1},
     {tenantId:1,companyId:1,id: 172, categoryType: 30, parentId: 164, value: 'Grand Touring', active: 1},

    // Mazda 3 Grades
     {tenantId:1,companyId:1,id: 173, categoryType: 30, parentId: 165, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 174, categoryType: 30, parentId: 165, value: 'Touring', active: 1},
     {tenantId:1,companyId:1,id: 175, categoryType: 30, parentId: 165, value: 'Grand Touring', active: 1},

    // Mazda 6 Grades
     {tenantId:1,companyId:1,id: 176, categoryType: 30, parentId: 166, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 177, categoryType: 30, parentId: 166, value: 'Touring', active: 1},
     {tenantId:1,companyId:1,id: 178, categoryType: 30, parentId: 166, value: 'Grand Touring', active: 1},
     {tenantId:1,companyId:1,id: 179, categoryType: 30, parentId: 166, value: 'Signature', active: 1},

    // Mazda CX-3 Grades
     {tenantId:1,companyId:1,id: 180, categoryType: 30, parentId: 167, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 181, categoryType: 30, parentId: 167, value: 'Touring', active: 1},
     {tenantId:1,companyId:1,id: 182, categoryType: 30, parentId: 167, value: 'Grand Touring', active: 1},

    // Mazda CX-5 Grades
     {tenantId:1,companyId:1,id: 183, categoryType: 30, parentId: 168, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 184, categoryType: 30, parentId: 168, value: 'Touring', active: 1},
     {tenantId:1,companyId:1,id: 185, categoryType: 30, parentId: 168, value: 'Grand Touring', active: 1},
     {tenantId:1,companyId:1,id: 186, categoryType: 30, parentId: 168, value: 'Signature', active: 1},

    // Mazda CX-9 Grades
     {tenantId:1,companyId:1,id: 187, categoryType: 30, parentId: 169, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 188, categoryType: 30, parentId: 169, value: 'Touring', active: 1},
     {tenantId:1,companyId:1,id: 189, categoryType: 30, parentId: 169, value: 'Grand Touring', active: 1},
     {tenantId:1,companyId:1,id: 190, categoryType: 30, parentId: 169, value: 'Signature', active: 1},

    // Mitsubishi Models
     {tenantId:1,companyId:1,id: 191, categoryType: 20, parentId: 6, value: 'Mitsubishi Lancer', active: 1},
     {tenantId:1,companyId:1,id: 192, categoryType: 20, parentId: 6, value: 'Mitsubishi Outlander', active: 1},
     {tenantId:1,companyId:1,id: 193, categoryType: 20, parentId: 6, value: 'Mitsubishi Pajero', active: 1},
     {tenantId:1,companyId:1,id: 194, categoryType: 20, parentId: 6, value: 'Mitsubishi Mirage', active: 1},
     {tenantId:1,companyId:1,id: 195, categoryType: 20, parentId: 6, value: 'Mitsubishi ASX', active: 1},

    // Mitsubishi Lancer Grades
     {tenantId:1,companyId:1,id: 196, categoryType: 30, parentId: 191, value: 'ES', active: 1},
     {tenantId:1,companyId:1,id: 197, categoryType: 30, parentId: 191, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 198, categoryType: 30, parentId: 191, value: 'SEL', active: 1},
     {tenantId:1,companyId:1,id: 199, categoryType: 30, parentId: 191, value: 'GT', active: 1},

    // Mitsubishi Outlander Grades
     {tenantId:1,companyId:1,id: 200, categoryType: 30, parentId: 192, value: 'ES', active: 1},
     {tenantId:1,companyId:1,id: 201, categoryType: 30, parentId: 192, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 202, categoryType: 30, parentId: 192, value: 'SEL', active: 1},
     {tenantId:1,companyId:1,id: 203, categoryType: 30, parentId: 192, value: 'GT', active: 1},

    // Mitsubishi Pajero Grades
     {tenantId:1,companyId:1,id: 204, categoryType: 30, parentId: 193, value: 'GLS', active: 1},
     {tenantId:1,companyId:1,id: 205, categoryType: 30, parentId: 193, value: 'Exceed', active: 1},

    // Mitsubishi Mirage Grades
     {tenantId:1,companyId:1,id: 206, categoryType: 30, parentId: 194, value: 'ES', active: 1},
     {tenantId:1,companyId:1,id: 207, categoryType: 30, parentId: 194, value: 'LE', active: 1},
     {tenantId:1,companyId:1,id: 208, categoryType: 30, parentId: 194, value: 'SE', active: 1},

    // Mitsubishi ASX Grades
     {tenantId:1,companyId:1,id: 209, categoryType: 30, parentId: 195, value: 'GLX', active: 1},
     {tenantId:1,companyId:1,id: 210, categoryType: 30, parentId: 195, value: 'GLS', active: 1},

    // Subaru Models
     {tenantId:1,companyId:1,id: 211, categoryType: 20, parentId: 7, value: 'Subaru Impreza', active: 1},
     {tenantId:1,companyId:1,id: 212, categoryType: 20, parentId: 7, value: 'Subaru Forester', active: 1},
     {tenantId:1,companyId:1,id: 213, categoryType: 20, parentId: 7, value: 'Subaru XV', active: 1},
     {tenantId:1,companyId:1,id: 214, categoryType: 20, parentId: 7, value: 'Subaru Legacy', active: 1},
     {tenantId:1,companyId:1,id: 215, categoryType: 20, parentId: 7, value: 'Subaru Outback', active: 1},

    // Subaru Impreza Grades
     {tenantId:1,companyId:1,id: 216, categoryType: 30, parentId: 211, value: 'Base', active: 1},
     {tenantId:1,companyId:1,id: 217, categoryType: 30, parentId: 211, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 218, categoryType: 30, parentId: 211, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 219, categoryType: 30, parentId: 211, value: 'Limited', active: 1},

    // Subaru Forester Grades
     {tenantId:1,companyId:1,id: 220, categoryType: 30, parentId: 212, value: 'Base', active: 1},
     {tenantId:1,companyId:1,id: 221, categoryType: 30, parentId: 212, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 222, categoryType: 30, parentId: 212, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 223, categoryType: 30, parentId: 212, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 224, categoryType: 30, parentId: 212, value: 'Touring', active: 1},

    // Subaru XV Grades
     {tenantId:1,companyId:1,id: 225, categoryType: 30, parentId: 213, value: 'Base', active: 1},
     {tenantId:1,companyId:1,id: 226, categoryType: 30, parentId: 213, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 227, categoryType: 30, parentId: 213, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 228, categoryType: 30, parentId: 213, value: 'Limited', active: 1},

    // Subaru Legacy Grades
     {tenantId:1,companyId:1,id: 229, categoryType: 30, parentId: 214, value: 'Base', active: 1},
     {tenantId:1,companyId:1,id: 230, categoryType: 30, parentId: 214, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 231, categoryType: 30, parentId: 214, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 232, categoryType: 30, parentId: 214, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 233, categoryType: 30, parentId: 214, value: 'Touring XT', active: 1},

    // Subaru Outback Grades
     {tenantId:1,companyId:1,id: 234, categoryType: 30, parentId: 215, value: 'Base', active: 1},
     {tenantId:1,companyId:1,id: 235, categoryType: 30, parentId: 215, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 236, categoryType: 30, parentId: 215, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 237, categoryType: 30, parentId: 215, value: 'Touring', active: 1},
     {tenantId:1,companyId:1,id: 238, categoryType: 30, parentId: 215, value: 'Onyx Edition XT', active: 1},

    // Lexus Models
     {tenantId:1,companyId:1,id: 239, categoryType: 20, parentId: 8, value: 'Lexus IS', active: 1},
     {tenantId:1,companyId:1,id: 240, categoryType: 20, parentId: 8, value: 'Lexus ES', active: 1},
     {tenantId:1,companyId:1,id: 241, categoryType: 20, parentId: 8, value: 'Lexus RX', active: 1},
     {tenantId:1,companyId:1,id: 242, categoryType: 20, parentId: 8, value: 'Lexus NX', active: 1},
     {tenantId:1,companyId:1,id: 243, categoryType: 20, parentId: 8, value: 'Lexus LX', active: 1},

    // Lexus IS Grades
     {tenantId:1,companyId:1,id: 244, categoryType: 30, parentId: 239, value: 'IS 300', active: 1},
     {tenantId:1,companyId:1,id: 245, categoryType: 30, parentId: 239, value: 'IS 350', active: 1},
     {tenantId:1,companyId:1,id: 246, categoryType: 30, parentId: 239, value: 'IS 300h', active: 1},

    // Lexus ES Grades
     {tenantId:1,companyId:1,id: 247, categoryType: 30, parentId: 240, value: 'ES 250', active: 1},
     {tenantId:1,companyId:1,id: 248, categoryType: 30, parentId: 240, value: 'ES 300h', active: 1},
     {tenantId:1,companyId:1,id: 249, categoryType: 30, parentId: 240, value: 'ES 350', active: 1},

    // Lexus RX Grades
     {tenantId:1,companyId:1,id: 250, categoryType: 30, parentId: 241, value: 'RX 350', active: 1},
     {tenantId:1,companyId:1,id: 251, categoryType: 30, parentId: 241, value: 'RX 450h', active: 1},
     {tenantId:1,companyId:1,id: 252, categoryType: 30, parentId: 241, value: 'RX 350L', active: 1},

    // Lexus NX Grades
     {tenantId:1,companyId:1,id: 253, categoryType: 30, parentId: 242, value: 'NX 200t', active: 1},
     {tenantId:1,companyId:1,id: 254, categoryType: 30, parentId: 242, value: 'NX 300', active: 1},
     {tenantId:1,companyId:1,id: 255, categoryType: 30, parentId: 242, value: 'NX 300h', active: 1},

    // Lexus LX Grades
     {tenantId:1,companyId:1,id: 256, categoryType: 30, parentId: 243, value: 'LX 570', active: 1},
     {tenantId:1,companyId:1,id: 257, categoryType: 30, parentId: 243, value: 'LX 600', active: 1},

    // Isuzu Models
     {tenantId:1,companyId:1,id: 258, categoryType: 20, parentId: 9, value: 'Isuzu D-Max', active: 1},
     {tenantId:1,companyId:1,id: 259, categoryType: 20, parentId: 9, value: 'Isuzu MU-X', active: 1},
     {tenantId:1,companyId:1,id: 260, categoryType: 20, parentId: 9, value: 'Isuzu Elf', active: 1},

    // Isuzu D-Max Grades
     {tenantId:1,companyId:1,id: 261, categoryType: 30, parentId: 258, value: 'Single Cab', active: 1},
     {tenantId:1,companyId:1,id: 262, categoryType: 30, parentId: 258, value: 'Double Cab', active: 1},
     {tenantId:1,companyId:1,id: 263, categoryType: 30, parentId: 258, value: 'V-Cross', active: 1},

    // Isuzu MU-X Grades
     {tenantId:1,companyId:1,id: 264, categoryType: 30, parentId: 259, value: 'Standard', active: 1},
     {tenantId:1,companyId:1,id: 265, categoryType: 30, parentId: 259, value: 'Luxury', active: 1},

    // Isuzu Elf Grades
     {tenantId:1,companyId:1,id: 266, categoryType: 30, parentId: 260, value: 'Standard', active: 1},
     {tenantId:1,companyId:1,id: 267, categoryType: 30, parentId: 260, value: 'High Roof', active: 1},

    // Hyundai Models
     {tenantId:1,companyId:1,id: 268, categoryType: 20, parentId: 10, value: 'Hyundai Elantra', active: 1},
     {tenantId:1,companyId:1,id: 269, categoryType: 20, parentId: 10, value: 'Hyundai Sonata', active: 1},
     {tenantId:1,companyId:1,id: 270, categoryType: 20, parentId: 10, value: 'Hyundai Tucson', active: 1},
     {tenantId:1,companyId:1,id: 271, categoryType: 20, parentId: 10, value: 'Hyundai Santa Fe', active: 1},
     {tenantId:1,companyId:1,id: 272, categoryType: 20, parentId: 10, value: 'Hyundai Accent', active: 1},

    // Hyundai Elantra Grades
     {tenantId:1,companyId:1,id: 273, categoryType: 30, parentId: 268, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 274, categoryType: 30, parentId: 268, value: 'SEL', active: 1},
     {tenantId:1,companyId:1,id: 275, categoryType: 30, parentId: 268, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 276, categoryType: 30, parentId: 268, value: 'N Line', active: 1},

    // Hyundai Sonata Grades
     {tenantId:1,companyId:1,id: 277, categoryType: 30, parentId: 269, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 278, categoryType: 30, parentId: 269, value: 'SEL', active: 1},
     {tenantId:1,companyId:1,id: 279, categoryType: 30, parentId: 269, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 280, categoryType: 30, parentId: 269, value: 'N Line', active: 1},

    // Hyundai Tucson Grades
     {tenantId:1,companyId:1,id: 281, categoryType: 30, parentId: 270, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 282, categoryType: 30, parentId: 270, value: 'SEL', active: 1},
     {tenantId:1,companyId:1,id: 283, categoryType: 30, parentId: 270, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 284, categoryType: 30, parentId: 270, value: 'N Line', active: 1},

    // Hyundai Santa Fe Grades
     {tenantId:1,companyId:1,id: 285, categoryType: 30, parentId: 271, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 286, categoryType: 30, parentId: 271, value: 'SEL', active: 1},
     {tenantId:1,companyId:1,id: 287, categoryType: 30, parentId: 271, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 288, categoryType: 30, parentId: 271, value: 'Calligraphy', active: 1},

    // Hyundai Accent Grades
     {tenantId:1,companyId:1,id: 289, categoryType: 30, parentId: 272, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 290, categoryType: 30, parentId: 272, value: 'SEL', active: 1},
     {tenantId:1,companyId:1,id: 291, categoryType: 30, parentId: 272, value: 'Limited', active: 1},

    // Kia Models
     {tenantId:1,companyId:1,id: 292, categoryType: 20, parentId: 11, value: 'Kia Picanto', active: 1},
     {tenantId:1,companyId:1,id: 293, categoryType: 20, parentId: 11, value: 'Kia Rio', active: 1},
     {tenantId:1,companyId:1,id: 294, categoryType: 20, parentId: 11, value: 'Kia Sportage', active: 1},
     {tenantId:1,companyId:1,id: 295, categoryType: 20, parentId: 11, value: 'Kia Sorento', active: 1},
     {tenantId:1,companyId:1,id: 296, categoryType: 20, parentId: 11, value: 'Kia Seltos', active: 1},

    // Kia Picanto Grades
     {tenantId:1,companyId:1,id: 297, categoryType: 30, parentId: 292, value: 'LX', active: 1},
     {tenantId:1,companyId:1,id: 298, categoryType: 30, parentId: 292, value: 'EX', active: 1},
     {tenantId:1,companyId:1,id: 299, categoryType: 30, parentId: 292, value: 'GT-Line', active: 1},

    // Kia Rio Grades
     {tenantId:1,companyId:1,id: 300, categoryType: 30, parentId: 293, value: 'LX', active: 1},
     {tenantId:1,companyId:1,id: 301, categoryType: 30, parentId: 293, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 302, categoryType: 30, parentId: 293, value: 'EX', active: 1},

    // Kia Sportage Grades
     {tenantId:1,companyId:1,id: 303, categoryType: 30, parentId: 294, value: 'LX', active: 1},
     {tenantId:1,companyId:1,id: 304, categoryType: 30, parentId: 294, value: 'EX', active: 1},
     {tenantId:1,companyId:1,id: 305, categoryType: 30, parentId: 294, value: 'SX Turbo', active: 1},

    // Kia Sorento Grades
     {tenantId:1,companyId:1,id: 306, categoryType: 30, parentId: 295, value: 'LX', active: 1},
     {tenantId:1,companyId:1,id: 307, categoryType: 30, parentId: 295, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 308, categoryType: 30, parentId: 295, value: 'EX', active: 1},
     {tenantId:1,companyId:1,id: 309, categoryType: 30, parentId: 295, value: 'SX', active: 1},

    // Kia Seltos Grades
     {tenantId:1,companyId:1,id: 310, categoryType: 30, parentId: 296, value: 'LX', active: 1},
     {tenantId:1,companyId:1,id: 311, categoryType: 30, parentId: 296, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 312, categoryType: 30, parentId: 296, value: 'EX', active: 1},
     {tenantId:1,companyId:1,id: 313, categoryType: 30, parentId: 296, value: 'SX Turbo', active: 1},

    // BMW Models
     {tenantId:1,companyId:1,id: 314, categoryType: 20, parentId: 12, value: 'BMW 3 Series', active: 1},
     {tenantId:1,companyId:1,id: 315, categoryType: 20, parentId: 12, value: 'BMW 5 Series', active: 1},
     {tenantId:1,companyId:1,id: 316, categoryType: 20, parentId: 12, value: 'BMW X1', active: 1},
     {tenantId:1,companyId:1,id: 317, categoryType: 20, parentId: 12, value: 'BMW X3', active: 1},
     {tenantId:1,companyId:1,id: 318, categoryType: 20, parentId: 12, value: 'BMW X5', active: 1},

    // BMW 3 Series Grades
     {tenantId:1,companyId:1,id: 319, categoryType: 30, parentId: 314, value: '320i', active: 1},
     {tenantId:1,companyId:1,id: 320, categoryType: 30, parentId: 314, value: '330i', active: 1},
     {tenantId:1,companyId:1,id: 321, categoryType: 30, parentId: 314, value: 'M340i', active: 1},

    // BMW 5 Series Grades
     {tenantId:1,companyId:1,id: 322, categoryType: 30, parentId: 315, value: '520i', active: 1},
     {tenantId:1,companyId:1,id: 323, categoryType: 30, parentId: 315, value: '530i', active: 1},
     {tenantId:1,companyId:1,id: 324, categoryType: 30, parentId: 315, value: '540i', active: 1},

    // BMW X1 Grades
     {tenantId:1,companyId:1,id: 325, categoryType: 30, parentId: 316, value: 'sDrive18i', active: 1},
     {tenantId:1,companyId:1,id: 326, categoryType: 30, parentId: 316, value: 'xDrive20i', active: 1},

    // BMW X3 Grades
     {tenantId:1,companyId:1,id: 327, categoryType: 30, parentId: 317, value: 'xDrive20i', active: 1},
     {tenantId:1,companyId:1,id: 328, categoryType: 30, parentId: 317, value: 'xDrive30i', active: 1},
     {tenantId:1,companyId:1,id: 329, categoryType: 30, parentId: 317, value: 'M40i', active: 1},

    // BMW X5 Grades
     {tenantId:1,companyId:1,id: 330, categoryType: 30, parentId: 318, value: 'xDrive40i', active: 1},
     {tenantId:1,companyId:1,id: 331, categoryType: 30, parentId: 318, value: 'xDrive45e', active: 1},
     {tenantId:1,companyId:1,id: 332, categoryType: 30, parentId: 318, value: 'M50i', active: 1},

    // Mercedes-Benz Models
     {tenantId:1,companyId:1,id: 333, categoryType: 20, parentId: 13, value: 'Mercedes-Benz C-Class', active: 1},
     {tenantId:1,companyId:1,id: 334, categoryType: 20, parentId: 13, value: 'Mercedes-Benz E-Class', active: 1},
     {tenantId:1,companyId:1,id: 335, categoryType: 20, parentId: 13, value: 'Mercedes-Benz GLC', active: 1},
     {tenantId:1,companyId:1,id: 336, categoryType: 20, parentId: 13, value: 'Mercedes-Benz GLE', active: 1},
     {tenantId:1,companyId:1,id: 337, categoryType: 20, parentId: 13, value: 'Mercedes-Benz S-Class', active: 1},

    // Mercedes-Benz C-Class Grades
     {tenantId:1,companyId:1,id: 338, categoryType: 30, parentId: 333, value: 'C 180', active: 1},
     {tenantId:1,companyId:1,id: 339, categoryType: 30, parentId: 333, value: 'C 200', active: 1},
     {tenantId:1,companyId:1,id: 340, categoryType: 30, parentId: 333, value: 'C 300', active: 1},
     {tenantId:1,companyId:1,id: 341, categoryType: 30, parentId: 333, value: 'AMG C 43', active: 1},

    // Mercedes-Benz E-Class Grades
     {tenantId:1,companyId:1,id: 342, categoryType: 30, parentId: 334, value: 'E 200', active: 1},
     {tenantId:1,companyId:1,id: 343, categoryType: 30, parentId: 334, value: 'E 300', active: 1},
     {tenantId:1,companyId:1,id: 344, categoryType: 30, parentId: 334, value: 'E 350', active: 1},
     {tenantId:1,companyId:1,id: 345, categoryType: 30, parentId: 334, value: 'AMG E 53', active: 1},

    // Mercedes-Benz GLC Grades
     {tenantId:1,companyId:1,id: 346, categoryType: 30, parentId: 335, value: 'GLC 200', active: 1},
     {tenantId:1,companyId:1,id: 347, categoryType: 30, parentId: 335, value: 'GLC 300', active: 1},
     {tenantId:1,companyId:1,id: 348, categoryType: 30, parentId: 335, value: 'AMG GLC 43', active: 1},

    // Mercedes-Benz GLE Grades
     {tenantId:1,companyId:1,id: 349, categoryType: 30, parentId: 336, value: 'GLE 350', active: 1},
     {tenantId:1,companyId:1,id: 350, categoryType: 30, parentId: 336, value: 'GLE 450', active: 1},
     {tenantId:1,companyId:1,id: 351, categoryType: 30, parentId: 336, value: 'AMG GLE 53', active: 1},

    // Mercedes-Benz S-Class Grades
     {tenantId:1,companyId:1,id: 352, categoryType: 30, parentId: 337, value: 'S 450', active: 1},
     {tenantId:1,companyId:1,id: 353, categoryType: 30, parentId: 337, value: 'S 500', active: 1},
     {tenantId:1,companyId:1,id: 354, categoryType: 30, parentId: 337, value: 'S 580', active: 1},

    // Audi Models
     {tenantId:1,companyId:1,id: 355, categoryType: 20, parentId: 14, value: 'Audi A3', active: 1},
     {tenantId:1,companyId:1,id: 356, categoryType: 20, parentId: 14, value: 'Audi A4', active: 1},
     {tenantId:1,companyId:1,id: 357, categoryType: 20, parentId: 14, value: 'Audi Q3', active: 1},
     {tenantId:1,companyId:1,id: 358, categoryType: 20, parentId: 14, value: 'Audi Q5', active: 1},
     {tenantId:1,companyId:1,id: 359, categoryType: 20, parentId: 14, value: 'Audi Q7', active: 1},

    // Audi A3 Grades
     {tenantId:1,companyId:1,id: 360, categoryType: 30, parentId: 355, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 361, categoryType: 30, parentId: 355, value: 'Premium Plus', active: 1},
     {tenantId:1,companyId:1,id: 362, categoryType: 30, parentId: 355, value: 'Prestige', active: 1},

    // Audi A4 Grades
     {tenantId:1,companyId:1,id: 363, categoryType: 30, parentId: 356, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 364, categoryType: 30, parentId: 356, value: 'Premium Plus', active: 1},
     {tenantId:1,companyId:1,id: 365, categoryType: 30, parentId: 356, value: 'Prestige', active: 1},

    // Audi Q3 Grades
     {tenantId:1,companyId:1,id: 366, categoryType: 30, parentId: 357, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 367, categoryType: 30, parentId: 357, value: 'Premium Plus', active: 1},
     {tenantId:1,companyId:1,id: 368, categoryType: 30, parentId: 357, value: 'Prestige', active: 1},

    // Audi Q5 Grades
     {tenantId:1,companyId:1,id: 369, categoryType: 30, parentId: 358, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 370, categoryType: 30, parentId: 358, value: 'Premium Plus', active: 1},
     {tenantId:1,companyId:1,id: 371, categoryType: 30, parentId: 358, value: 'Prestige', active: 1},

    // Audi Q7 Grades
     {tenantId:1,companyId:1,id: 372, categoryType: 30, parentId: 359, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 373, categoryType: 30, parentId: 359, value: 'Premium Plus', active: 1},
     {tenantId:1,companyId:1,id: 374, categoryType: 30, parentId: 359, value: 'Prestige', active: 1},

    // Ford Models
     {tenantId:1,companyId:1,id: 375, categoryType: 20, parentId: 17, value: 'Ford Fiesta', active: 1},
     {tenantId:1,companyId:1,id: 376, categoryType: 20, parentId: 17, value: 'Ford Focus', active: 1},
     {tenantId:1,companyId:1,id: 377, categoryType: 20, parentId: 17, value: 'Ford Mustang', active: 1},
     {tenantId:1,companyId:1,id: 378, categoryType: 20, parentId: 17, value: 'Ford Ranger', active: 1},
     {tenantId:1,companyId:1,id: 379, categoryType: 20, parentId: 17, value: 'Ford Explorer', active: 1},

    // Ford Fiesta Grades
     {tenantId:1,companyId:1,id: 380, categoryType: 30, parentId: 375, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 381, categoryType: 30, parentId: 375, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 382, categoryType: 30, parentId: 375, value: 'Titanium', active: 1},

    // Ford Focus Grades
     {tenantId:1,companyId:1,id: 383, categoryType: 30, parentId: 376, value: 'S', active: 1},
     {tenantId:1,companyId:1,id: 384, categoryType: 30, parentId: 376, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 385, categoryType: 30, parentId: 376, value: 'Titanium', active: 1},
     {tenantId:1,companyId:1,id: 386, categoryType: 30, parentId: 376, value: 'ST', active: 1},

    // Ford Mustang Grades
     {tenantId:1,companyId:1,id: 387, categoryType: 30, parentId: 377, value: 'EcoBoost', active: 1},
     {tenantId:1,companyId:1,id: 388, categoryType: 30, parentId: 377, value: 'GT', active: 1},
     {tenantId:1,companyId:1,id: 389, categoryType: 30, parentId: 377, value: 'Mach 1', active: 1},
     {tenantId:1,companyId:1,id: 390, categoryType: 30, parentId: 377, value: 'Shelby GT500', active: 1},

    // Ford Ranger Grades
     {tenantId:1,companyId:1,id: 391, categoryType: 30, parentId: 378, value: 'XL', active: 1},
     {tenantId:1,companyId:1,id: 392, categoryType: 30, parentId: 378, value: 'XLT', active: 1},
     {tenantId:1,companyId:1,id: 393, categoryType: 30, parentId: 378, value: 'Lariat', active: 1},
     {tenantId:1,companyId:1,id: 394, categoryType: 30, parentId: 378, value: 'Wildtrak', active: 1},

    // Ford Explorer Grades
     {tenantId:1,companyId:1,id: 395, categoryType: 30, parentId: 379, value: 'Base', active: 1},
     {tenantId:1,companyId:1,id: 396, categoryType: 30, parentId: 379, value: 'XLT', active: 1},
     {tenantId:1,companyId:1,id: 397, categoryType: 30, parentId: 379, value: 'Limited', active: 1},
     {tenantId:1,companyId:1,id: 398, categoryType: 30, parentId: 379, value: 'ST', active: 1},

    // Tesla Models
     {tenantId:1,companyId:1,id: 399, categoryType: 20, parentId: 18, value: 'Tesla Model S', active: 1},
     {tenantId:1,companyId:1,id: 400, categoryType: 20, parentId: 18, value: 'Tesla Model 3', active: 1},
     {tenantId:1,companyId:1,id: 401, categoryType: 20, parentId: 18, value: 'Tesla Model X', active: 1},
     {tenantId:1,companyId:1,id: 402, categoryType: 20, parentId: 18, value: 'Tesla Model Y', active: 1},

    // Tesla Grades
     {tenantId:1,companyId:1,id: 403, categoryType: 30, parentId: 399, value: 'Long Range', active: 1},
     {tenantId:1,companyId:1,id: 404, categoryType: 30, parentId: 399, value: 'Plaid', active: 1},
     {tenantId:1,companyId:1,id: 405, categoryType: 30, parentId: 400, value: 'Standard Range Plus', active: 1},
     {tenantId:1,companyId:1,id: 406, categoryType: 30, parentId: 400, value: 'Long Range', active: 1},
     {tenantId:1,companyId:1,id: 407, categoryType: 30, parentId: 400, value: 'Performance', active: 1},
     {tenantId:1,companyId:1,id: 408, categoryType: 30, parentId: 401, value: 'Long Range', active: 1},
     {tenantId:1,companyId:1,id: 409, categoryType: 30, parentId: 401, value: 'Plaid', active: 1},
     {tenantId:1,companyId:1,id: 410, categoryType: 30, parentId: 402, value: 'Long Range', active: 1},
     {tenantId:1,companyId:1,id: 411, categoryType: 30, parentId: 402, value: 'Performance', active: 1},

    // Renault Models
     {tenantId:1,companyId:1,id: 412, categoryType: 20, parentId: 19, value: 'Renault Clio', active: 1},
     {tenantId:1,companyId:1,id: 413, categoryType: 20, parentId: 19, value: 'Renault Megane', active: 1},
     {tenantId:1,companyId:1,id: 414, categoryType: 20, parentId: 19, value: 'Renault Captur', active: 1},
     {tenantId:1,companyId:1,id: 415, categoryType: 20, parentId: 19, value: 'Renault Duster', active: 1},

    // Renault Grades
     {tenantId:1,companyId:1,id: 416, categoryType: 30, parentId: 412, value: 'Authentique', active: 1},
     {tenantId:1,companyId:1,id: 417, categoryType: 30, parentId: 412, value: 'Expression', active: 1},
     {tenantId:1,companyId:1,id: 418, categoryType: 30, parentId: 412, value: 'Dynamique', active: 1},
     {tenantId:1,companyId:1,id: 419, categoryType: 30, parentId: 413, value: 'Life', active: 1},
     {tenantId:1,companyId:1,id: 420, categoryType: 30, parentId: 413, value: 'Zen', active: 1},
     {tenantId:1,companyId:1,id: 421, categoryType: 30, parentId: 413, value: 'Intens', active: 1},
     {tenantId:1,companyId:1,id: 422, categoryType: 30, parentId: 414, value: 'Life', active: 1},
     {tenantId:1,companyId:1,id: 423, categoryType: 30, parentId: 414, value: 'Zen', active: 1},
     {tenantId:1,companyId:1,id: 424, categoryType: 30, parentId: 414, value: 'Intens', active: 1},
     {tenantId:1,companyId:1,id: 425, categoryType: 30, parentId: 415, value: 'RXE', active: 1},
     {tenantId:1,companyId:1,id: 426, categoryType: 30, parentId: 415, value: 'RXL', active: 1},
     {tenantId:1,companyId:1,id: 427, categoryType: 30, parentId: 415, value: 'RXZ', active: 1},

    // Fiat Models
     {tenantId:1,companyId:1,id: 428, categoryType: 20, parentId: 21, value: 'Fiat 500', active: 1},
     {tenantId:1,companyId:1,id: 429, categoryType: 20, parentId: 21, value: 'Fiat Panda', active: 1},
     {tenantId:1,companyId:1,id: 430, categoryType: 20, parentId: 21, value: 'Fiat Tipo', active: 1},

    // Fiat Grades
     {tenantId:1,companyId:1,id: 431, categoryType: 30, parentId: 428, value: 'Pop', active: 1},
     {tenantId:1,companyId:1,id: 432, categoryType: 30, parentId: 428, value: 'Lounge', active: 1},
     {tenantId:1,companyId:1,id: 433, categoryType: 30, parentId: 428, value: 'Sport', active: 1},
     {tenantId:1,companyId:1,id: 434, categoryType: 30, parentId: 429, value: 'Easy', active: 1},
     {tenantId:1,companyId:1,id: 435, categoryType: 30, parentId: 429, value: 'Lounge', active: 1},
     {tenantId:1,companyId:1,id: 436, categoryType: 30, parentId: 430, value: 'Street', active: 1},
     {tenantId:1,companyId:1,id: 437, categoryType: 30, parentId: 430, value: 'Mirror', active: 1},
     {tenantId:1,companyId:1,id: 438, categoryType: 30, parentId: 430, value: 'Sport', active: 1},

    // Land Rover Models
     {tenantId:1,companyId:1,id: 439, categoryType: 20, parentId: 22, value: 'Land Rover Range Rover', active: 1},
     {tenantId:1,companyId:1,id: 440, categoryType: 20, parentId: 22, value: 'Land Rover Discovery', active: 1},
     {tenantId:1,companyId:1,id: 441, categoryType: 20, parentId: 22, value: 'Land Rover Defender', active: 1},

    // Land Rover Grades
     {tenantId:1,companyId:1,id: 442, categoryType: 30, parentId: 439, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 443, categoryType: 30, parentId: 439, value: 'HSE', active: 1},
     {tenantId:1,companyId:1,id: 444, categoryType: 30, parentId: 439, value: 'Autobiography', active: 1},
     {tenantId:1,companyId:1,id: 445, categoryType: 30, parentId: 440, value: 'SE', active: 1},
     {tenantId:1,companyId:1,id: 446, categoryType: 30, parentId: 440, value: 'HSE', active: 1},
     {tenantId:1,companyId:1,id: 447, categoryType: 30, parentId: 441, value: 'Standard', active: 1},
     {tenantId:1,companyId:1,id: 448, categoryType: 30, parentId: 441, value: 'X-Dynamic', active: 1},
     {tenantId:1,companyId:1,id: 449, categoryType: 30, parentId: 441, value: 'X', active: 1},

    // Volvo Models
     {tenantId:1,companyId:1,id: 450, categoryType: 20, parentId: 23, value: 'Volvo XC40', active: 1},
     {tenantId:1,companyId:1,id: 451, categoryType: 20, parentId: 23, value: 'Volvo XC60', active: 1},
     {tenantId:1,companyId:1,id: 452, categoryType: 20, parentId: 23, value: 'Volvo XC90', active: 1},

    // Volvo Grades
     {tenantId:1,companyId:1,id: 453, categoryType: 30, parentId: 450, value: 'Momentum', active: 1},
     {tenantId:1,companyId:1,id: 454, categoryType: 30, parentId: 450, value: 'R-Design', active: 1},
     {tenantId:1,companyId:1,id: 455, categoryType: 30, parentId: 450, value: 'Inscription', active: 1},
     {tenantId:1,companyId:1,id: 456, categoryType: 30, parentId: 451, value: 'Momentum', active: 1},
     {tenantId:1,companyId:1,id: 457, categoryType: 30, parentId: 451, value: 'R-Design', active: 1},
     {tenantId:1,companyId:1,id: 458, categoryType: 30, parentId: 451, value: 'Inscription', active: 1},
     {tenantId:1,companyId:1,id: 459, categoryType: 30, parentId: 452, value: 'Momentum', active: 1},
     {tenantId:1,companyId:1,id: 460, categoryType: 30, parentId: 452, value: 'R-Design', active: 1},
     {tenantId:1,companyId:1,id: 461, categoryType: 30, parentId: 452, value: 'Inscription', active: 1},

    // BYD Models
     {tenantId:1,companyId:1,id: 462, categoryType: 20, parentId: 24, value: 'BYD Atto 3', active: 1},
     {tenantId:1,companyId:1,id: 463, categoryType: 20, parentId: 24, value: 'BYD Dolphin', active: 1},
     {tenantId:1,companyId:1,id: 464, categoryType: 20, parentId: 24, value: 'BYD Han', active: 1},

    // BYD Grades
     {tenantId:1,companyId:1,id: 465, categoryType: 30, parentId: 462, value: 'Standard', active: 1},
     {tenantId:1,companyId:1,id: 466, categoryType: 30, parentId: 462, value: 'Extended Range', active: 1},
     {tenantId:1,companyId:1,id: 467, categoryType: 30, parentId: 463, value: 'Standard', active: 1},
     {tenantId:1,companyId:1,id: 468, categoryType: 30, parentId: 463, value: 'Premium', active: 1},
     {tenantId:1,companyId:1,id: 469, categoryType: 30, parentId: 464, value: 'EV', active: 1},
     {tenantId:1,companyId:1,id: 470, categoryType: 30, parentId: 464, value: 'DM', active: 1},

    // Chery Models
     {tenantId:1,companyId:1,id: 471, categoryType: 20, parentId: 25, value: 'Chery Tiggo 4', active: 1},
     {tenantId:1,companyId:1,id: 472, categoryType: 20, parentId: 25, value: 'Chery Tiggo 7', active: 1},
     {tenantId:1,companyId:1,id: 473, categoryType: 20, parentId: 25, value: 'Chery Tiggo 8', active: 1},

    // Chery Grades
     {tenantId:1,companyId:1,id: 474, categoryType: 30, parentId: 471, value: 'Comfort', active: 1},
     {tenantId:1,companyId:1,id: 475, categoryType: 30, parentId: 471, value: 'Luxury', active: 1},
     {tenantId:1,companyId:1,id: 476, categoryType: 30, parentId: 472, value: 'Comfort', active: 1},
     {tenantId:1,companyId:1,id: 477, categoryType: 30, parentId: 472, value: 'Luxury', active: 1},
     {tenantId:1,companyId:1,id: 478, categoryType: 30, parentId: 473, value: 'Comfort', active: 1},
     {tenantId:1,companyId:1,id: 479, categoryType: 30, parentId: 473, value: 'Luxury', active: 1},

     {tenantId:1,companyId:1,id: 1, categoryType: 40, value: 'Petral', active: 1},
     {tenantId:1,companyId:1,id: 2, categoryType: 40, value: 'Diesel', active: 1},
     {tenantId:1,companyId:1,id: 3, categoryType: 40, value: 'Hybrid', active: 1},
     {tenantId:1,companyId:1,id: 4, categoryType: 40, value: 'Electric', active: 1},
     {tenantId:1,companyId:1,id: 5, categoryType: 40, value: 'Plug-in Hybrid', active: 1},

         {tenantId:1,companyId:1,id: 1, categoryType: 50, value: 'Manual', active: 1},
         {tenantId:1,companyId:1,id: 2, categoryType: 50, value: 'Automatic', active: 1},
         {tenantId:1,companyId:1,id: 3, categoryType: 50, value: 'CVT', active: 1},
         {tenantId:1,companyId:1,id: 4, categoryType: 50, value: 'DCT', active: 1},

        {tenantId:1,companyId:1,id: 1, categoryType: 60, value: 'White', active: 1},
        {tenantId:1,companyId:1,id: 2, categoryType: 60, value: 'Black', active: 1},
        {tenantId:1,companyId:1,id: 3, categoryType: 60, value: 'Silver', active: 1},
        {tenantId:1,companyId:1,id: 4, categoryType: 60, value: 'Blue', active: 1},
        {tenantId:1,companyId:1,id: 5, categoryType: 60, value: 'Red', active: 1},
        {tenantId:1,companyId:1,id: 6, categoryType: 60, value: 'Gray', active: 1},
        {tenantId:1,companyId:1,id: 7, categoryType: 60, value: 'Green', active: 1},
        {tenantId:1,companyId:1,id: 5, categoryType: 60, value: 'Brown', active: 1},
        {tenantId:1,companyId:1,id: 6, categoryType: 60, value: 'Beige', active: 1},
        {tenantId:1,companyId:1,id: 7, categoryType: 60, value: 'Yellow', active: 1},
        {tenantId:1,companyId:1,id: 8, categoryType: 60, value: 'Orange', active: 1},
        {tenantId:1,companyId:1,id: 9, categoryType: 60, value: 'Gold', active: 1},
        {tenantId:1,companyId:1,id: 10, categoryType: 60, value: 'Midnight Silver', active: 1},

        {tenantId:1,companyId:1,id: 1, categoryType: 70, value: 'Car', active: 1},
        {tenantId:1,companyId:1,id: 2, categoryType: 70, value: 'Van', active: 1},
        {tenantId:1,companyId:1,id: 3, categoryType: 70, value: 'Truck', active: 1},
        {tenantId:1,companyId:1,id: 4, categoryType: 70, value: 'Bus', active: 1},
  ];

  const mappedData = data.map(({ active, parentId, ...item }) => ({
    ...item,
    parentId: parentId || 0,
    isActive: active
  }));

  for (let i = 0; i < mappedData.length; i += 100) {
    await knex('ref_category').insert(mappedData.slice(i, i + 100));
  }
};
exports.down = function(knex) {
      return knex('ref_category')
        // .whereIn('categoryType', [10, 20, 30, 40, 50, 60])
        .del();
};


