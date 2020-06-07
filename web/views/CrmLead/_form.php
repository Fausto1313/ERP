<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\ResPartner */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="crm-lead-form">

    <?php $form = ActiveForm::begin(); ?>

     <?= $form->field($model, 'email_cc')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'message_main_attachment_id')->textInput() ?>

    <?= $form->field($model, 'message_bounce')->textInput() ?>

    <?= $form->field($model, 'email_normalized')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'campaign_id')->textInput() ?>

    <?= $form->field($model, 'source_id')->textInput() ?>

    <?= $form->field($model, 'medium_id')->textInput() ?>

    <?= $form->field($model, 'name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'partner_id')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'active')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'date_action_last')->textInput() ?>

    <?= $form->field($model, 'email_from')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'team_id')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'description')->textInput() ?>

    <?= $form->field($model, 'contact_name')->textInput() ?>

    <?= $form->field($model, 'partner_name')->textInput() ?>

    <?= $form->field($model, 'type')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'priority')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'date_closed')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'stage_id')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'user_id')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'referred')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'date_open')->textInput() ?>

    <?= $form->field($model, 'day_open')->textInput() ?>

    <?= $form->field($model, 'day_close')->textInput() ?>

    <?= $form->field($model, 'date_last_stage_update')->textInput() ?>

    <?= $form->field($model, 'date_conversion')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'probability')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'automated_probability')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'phone_state')->textInput() ?>

    <?= $form->field($model, 'email_state')->textInput() ?>

    <?= $form->field($model, 'planned_revenue')->textInput() ?>

    <?= $form->field($model, 'expected_revenue')->textInput() ?>

    <?= $form->field($model, 'date_deadline')->textInput() ?>

    <?= $form->field($model, 'color')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'street')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'street2')->textInput() ?>

    <?= $form->field($model, 'zip')->textInput() ?>

    <?= $form->field($model, 'city')->textInput() ?>

    <?= $form->field($model, 'state_id')->textInput() ?>

    <?= $form->field($model, 'country_id')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'lang_id')->textInput() ?>

    <?= $form->field($model, 'phone')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'mobile')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'function')->textInput() ?>

    <?= $form->field($model, 'title')->textInput() ?>

    <?= $form->field($model, 'company_id')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'lost_reason')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'trial242')->textarea(['rows' => 6]) ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
