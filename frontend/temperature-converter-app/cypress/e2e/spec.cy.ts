describe('My First Test', () => {
  it('Visits the initial project page', () => {
    cy.visit('/')
    cy.get('#convert').click()
    cy.contains('273.15')
  })
})
