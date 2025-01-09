const admin = require("firebase-admin");  // Правильне імпортування Firebase для Node.js
const chai = require("chai");
const expect = chai.expect;

admin.initializeApp({
    credential: admin.credential.applicationDefault(),
    databaseURL: "https://db-unity-3-default-rtdb.firebaseio.com"
});

const db = admin.database();  

describe("Firebase E2E Tests", function () {
    const testPath = "testPath";

    after(async () => {
        await db.ref(testPath).remove(); 
    });

    it("should write and read data", async function () {
        const testData = { name: "Test User", age: 25 };

        
        await db.ref(testPath).set(testData);

        
        const snapshot = await db.ref(testPath).once("value");
        const data = snapshot.val();

        
        expect(data).to.deep.equal(testData);
    });
});
