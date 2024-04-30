//check after email validation to  p tag invisible
import { mount } from '@vue/test-utils';
import AddReview from '@/views/AddReview.vue';

describe('AddReview', () => {
  it('validate email', async () => {
    const wrapper = mount(AddReview);

    wrapper.find('input#reviewername').setValue('rosszemail');
    await wrapper.vm.$nextTick();

    expect(wrapper.find('p').text()).toBe('Kérlek érvényes e-mail címet adj meg');

    wrapper.find('input#reviewername').setValue('valide@mail.com');
    await wrapper.vm.$nextTick();

    expect(wrapper.find('p').exists()).toBe(false);

  });
});
