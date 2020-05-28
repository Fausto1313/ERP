<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="res-users-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'id') ?>

    <?= $form->field($model, 'active') ?>

    <?= $form->field($model, 'login') ?>

    <?= $form->field($model, 'password') ?>

    <?= $form->field($model, 'company_id') ?>

    <?php // echo $form->field($model, 'partner_id') ?>

    <?php // echo $form->field($model, 'create_date') ?>

    <?php // echo $form->field($model, 'signature') ?>

    <?php // echo $form->field($model, 'action_id') ?>

    <?php // echo $form->field($model, 'share') ?>

    <?php // echo $form->field($model, 'create_uid') ?>

    <?php // echo $form->field($model, 'write_uid') ?>

    <?php // echo $form->field($model, 'write_date') ?>

    <?php // echo $form->field($model, 'alias_id') ?>

    <?php // echo $form->field($model, 'notification_type') ?>

    <?php // echo $form->field($model, 'out_of_office_message') ?>

    <?php // echo $form->field($model, 'odoobot_state') ?>

    <?php // echo $form->field($model, 'website_id') ?>

    <?php // echo $form->field($model, 'sale_team_id') ?>

    <?php // echo $form->field($model, 'target_sales_won') ?>

    <?php // echo $form->field($model, 'target_sales_done') ?>

    <?php // echo $form->field($model, 'target_sales_invoiced') ?>

    <?php // echo $form->field($model, 'karma') ?>

    <?php // echo $form->field($model, 'rank_id') ?>

    <?php // echo $form->field($model, 'next_rank_id') ?>

    <?php // echo $form->field($model, 'livechat_username') ?>

    <?php // echo $form->field($model, 'trial532') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
