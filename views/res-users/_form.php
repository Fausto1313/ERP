<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="res-users-form">

<?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'active')->textInput() ?>

    <?= $form->field($model, 'login')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'password')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'company_id')->textInput() ?>

    <?= $form->field($model, 'partner_id')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'signature')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'action_id')->textInput() ?>

    <?= $form->field($model, 'share')->textInput() ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'alias_id')->textInput() ?>

    <?= $form->field($model, 'notification_type')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'out_of_office_message')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'odoobot_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_id')->textInput() ?>

    <?= $form->field($model, 'sale_team_id')->textInput() ?>

    <?= $form->field($model, 'target_sales_won')->textInput() ?>

    <?= $form->field($model, 'target_sales_done')->textInput() ?>

    <?= $form->field($model, 'target_sales_invoiced')->textInput() ?>

    <?= $form->field($model, 'karma')->textInput() ?>

    <?= $form->field($model, 'rank_id')->textInput() ?>

    <?= $form->field($model, 'next_rank_id')->textInput() ?>

    <?= $form->field($model, 'livechat_username')->textarea(['rows' => 6]) ?>



    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
